using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Fixture;
using System.Globalization;

namespace SportSchedule.Services.Fixtures
{
    public class FixturesService : IFixturesService
    {
        private readonly ContextDB _context;
        private readonly HttpClient _httpClient;
        public FixturesService(ContextDB context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClient = httpClientFactory.CreateClient("FootballData");
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

        //Ham de do du lieu cho FE
        public async Task<List<FixtureDataFrontend>> GetFixtureDataFrontendsAsync(string date)
        {
            var data = await (from m in _context.Matches
                             join th in _context.Teams on m.TeamIdHome equals th.TeamId
                             join tw in _context.Teams on m.TeamIdAway equals tw.TeamId
                             join l in _context.Leagues on m.LeagueId equals l.LeagueId
                             select new FixtureDataFrontend
                             {
                                 LeagueName = l.Name,
                                 MatchId = m.MatchId,
                                 NameHome = th.Name,
                                 NameAway = tw.Name,
                                 Time = m.Time,
                                 GoalHome = 0,
                                 GoalAway = 0
                             }).ToListAsync();
            var fixtures = data.Where(m => m.Time.Split(' ')[0] == date).ToList();
            return fixtures;
        }

    }
}
