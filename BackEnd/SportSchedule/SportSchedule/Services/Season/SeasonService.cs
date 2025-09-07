
using Newtonsoft.Json.Linq;
using SportSchedule.DataAccess;
using SportSchedule.DataTranserferObject.Fixture;

namespace SportSchedule.Services.Season
{
    public class SeasonService : ISeasonService
    {
        private readonly HttpClient _httpClient;
        private readonly LeagueDAL _leagueDAL;
        private readonly SeasonDAL _seasonDAL;
        private readonly TeamDAL _teamDAL;
        public SeasonService(IHttpClientFactory httpClientFactory, LeagueDAL leagueDAL, SeasonDAL seasonDAL, TeamDAL teamDAL)
        {
            _httpClient = httpClientFactory.CreateClient("FootballData");
            _leagueDAL = leagueDAL;
            _seasonDAL = seasonDAL;
            _teamDAL = teamDAL;
        }
        public async Task<bool> addSeason()
        {
            bool isAddSeason = _seasonDAL.addSeason();
            if(_seasonDAL.getSeason())
                return false;
            if (isAddSeason)
            {
                string dateFrom = DateTime.Now.ToString("yyyy-MM-dd");
                string dateTo = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
                List<FixtureData> fixtures = new List<FixtureData>();
                var leagues = _leagueDAL.getLeaguesCode();
                foreach (var league in leagues)
                {
                    if (league != "WC")
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
                            _teamDAL.addTeam(fixture);

                            fixtures.Add(fixture);
                        }

                    }
                }
            }
            return false;
        }
    }
}
