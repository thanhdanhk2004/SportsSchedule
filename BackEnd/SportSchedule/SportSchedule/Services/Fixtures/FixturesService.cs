using Newtonsoft.Json.Linq;
using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Fixture;

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

        public async Task<List<FixtureData>> GetFixturesAsync(string date)
        {
            List<FixtureData> fixtures = new List<FixtureData>();
            var leagues = _context.Leagues.Select(l => l.Code).ToList();
            int i = 0;
            foreach (var league in leagues)
            {
                var response = await _httpClient.GetAsync($"competitions/{league}/matches?dateFrom={date}&dateTo={date}");
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
                        Round = (string?)item["matchday"] ?? "",
                        Season = (string?)json["filters"]?["season"] ?? "",
                        Date = (DateTime)(item["utcDate"] ?? DateTime.MinValue),
                        Venue = (string?)item["homeTeam"]?["shortName"] ?? "",
                        HomeId = (int)(item["homeTeam"]?["id"] ?? 0),
                        HomeLogo = (string?)item["homeTeam"]?["crest"] ?? "",
                        AwayId = (int)(item["awayTeam"]?["id"] ?? 0),
                        AwayLogo = (string?)item["awayTeam"]?["crest"] ?? "",
                        GoalHome = item["score"]?["fullTime"]?["home"]?.Type == JTokenType.Integer ? (int)item["score"]!["fullTime"]!["home"]! : 0,
                        GoalAway = item["score"]?["fullTime"]?["away"]?.Type == JTokenType.Integer ? (int)item["score"]!["fullTime"]!["away"]! : 0,
                    };
                    fixtures.Add(fixture);
                }
                if (i == 5)
                    break;
                i++;
            }

            return fixtures;
        }
    }
}
