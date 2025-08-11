using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Fixture;
using System.Globalization;
using Microsoft.Extensions.Caching.Memory;
using SportSchedule.DataAccess;

namespace SportSchedule.Services.Fixtures
{
    public class FixturesService : IFixturesService
    {
        private readonly ContextDB _context;
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private readonly MatchDAL _matchDAL;
        public FixturesService(ContextDB context, IHttpClientFactory httpClientFactory, IMemoryCache cache, MatchDAL matchDAL)
        {
            _context = context;
            _httpClient = httpClientFactory.CreateClient("FootballData");
            _cache = cache;
            _matchDAL = matchDAL;
        }

        //Ham de do du lieu vao DB
        public async Task<List<FixtureData>> GetFixturesAsync()
        {
            string dateFrom = DateTime.Now.ToString("yyyy-MM-dd");
            string dateTo = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
            List<FixtureData> fixtures = new List<FixtureData>();
            var leagues = _context.Leagues.Select(l => l.Code).ToList();
            
            foreach (var league in leagues)
            {
                if( league != "WC")
                {
                    var response = await _httpClient.GetAsync($"competitions/{league}/matches?dateFrom={dateFrom}&dateTo={dateTo}");
                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(content);

                    foreach (var item in json["matches"])
                    {
                        FixtureData fixture = new FixtureData
                        {
                            LeagueId = (int)(json["competition"]?["id"] ?? 0),
                            FixtureId = (int)(item["id"] ?? 0),
                            LeagueName = (string?)json["competition"]?["name"] ?? "",
                            Logo = (string?)json["competition"]?["emblem"] ?? "",
                            Country = (string?)item["area"]?["name"] ?? "",
                            Round = (string?)item["matchday"] ?? "",
                            Season = (string?)json["filters"]?["season"] ?? "",
                            Date = (DateTime)(item["utcDate"] ?? DateTime.MinValue),
                            Venue = (string?)item["homeTeam"]?["shortName"] ?? "",
                            HomeId = (int)(item["homeTeam"]?["id"] ?? 0),
                            HomeLogo = (string?)item["homeTeam"]?["crest"] ?? "",
                            HomeName = (string?)item["homeTeam"]?["name"] ?? "",
                            AwayName = (string?)item["awayTeam"]?["name"] ?? "",
                            AwayId = (int)(item["awayTeam"]?["id"] ?? 0),
                            AwayLogo = (string?)item["awayTeam"]?["crest"] ?? "",
                            GoalHome = item["score"]?["fullTime"]?["home"]?.Value<int?>() ?? 0,
                            GoalAway = item["score"]?["fullTime"]?["away"]?.Value<int?>() ?? 0,

                        };
                        fixtures.Add(fixture);
                    }
          
                }
            }

            return fixtures;
        }

        //Ham de lay du lieu cac tran dau cho FE (theo ngay)
        public async Task<List<FixtureDataFrontend>> GetFixturesByDateDataFrontendsAsync(string date)
        {
            string key_cache = $"fixtures_{date}";
            if(_cache.TryGetValue(key_cache, out List<FixtureDataFrontend> _listFixtures))
            {
                return _listFixtures!;
            }

            DateTime time = TimeZoneInfo.ConvertTimeToUtc(DateTime.ParseExact(date, "dd/MM", CultureInfo.InvariantCulture), TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));
            
            List <FixtureDataFrontend> data = _matchDAL.getFixturesByDateDAL(time, time.AddDays(1));

            if(data != null)
            {
                _cache.Set(key_cache, data, TimeSpan.FromMinutes(10));
            }
            return data;
        }

        //Ham lay du lieu cac tran dau cho FE(theo giai)
        public async Task<List<FixtureDataFrontend>> GetFixtruesByLeagueDataFrontendAsync(int league_id)
        {
            string key_cache = $"league_{league_id}";
            if (_cache.TryGetValue(key_cache, out List<FixtureDataFrontend> list)){
                return list!;
            }
            var data = _matchDAL.getFixtrueByLeagueDAL(league_id);
            if (data != null)
                _cache.Set(key_cache, data, TimeSpan.FromMinutes(30));
            return data;
        }

        //Ham de lay du lieu cua mot tran dau
        public async Task<FixtureDataFrontend> GetInfoFixtureAsync(int match_id, string date)
        {
            if(_cache.TryGetValue($"fixtures_{date}", out List<FixtureDataFrontend>? _listFixtures))
            {
                var result = _listFixtures?.FirstOrDefault(lf => lf.MatchId == match_id);
                return result!;
            }
            List<FixtureDataFrontend> _listFixture = await this.GetFixturesByDateDataFrontendsAsync(date);
            var fixture = _listFixtures?.FirstOrDefault(lf => lf.MatchId == match_id);
            return fixture!;
        }

        
    }
}
