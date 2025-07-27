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
            var leagues = _context.Leagues.Select(l => l.LeagueId).ToList();
            var response = await _httpClient.GetAsync("competitions/PL/matches?dateFrom=2025-08-25&dateTo=2025-08-30");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);

            foreach (var item in json["response"])
            {
                FixtureData fixture = new FixtureData
                {
                    LeagueId = (int)(item["competition"]?["id"] ?? 0),
                    FixtureId = (int)(item["matches"]?["id"] ?? 0),
                    LeagueName = (string?)item["competition"]?["name"] ?? "",
                    Logo = (string?)item["competition"]?["emblem"] ?? "",
                    Round = (string?)item["matches"]?["matchday"] ?? "",
                    Season = (int)(item["filters"]?["season"] ?? 0),
                    Date = (DateTime)(item["matches"]?["utcDate"] ?? DateTime.MinValue),
                    Venue = (string?)item["matches"]?["homeTeam"]?["shortName"] ?? "",
                    HomeId = (int)(item["matches"]?["homeTeam"]?["id"] ?? 0),
                    HomeLogo = (string?)item["matches"]?["homeTeam"]?["crest"] ?? "",
                    AwayId = (int)(item["matches"]?["awayTeam"]?["id"] ?? 0),
                    AwayLogo = (string?)item["matches"]?["awayTeam"]?["crest"] ?? "",
                    GoalHome = item["matches"]?["score"]?["fullTime"]?["home"]?.Type == JTokenType.Integer ? (int)item["matches"]!["score"]!["fullTime"]!["home"]! : 0,
                    GoalAway = item["matches"]?["score"]?["fullTime"]?["away"]?.Type == JTokenType.Integer ? (int)item["matches"]!["score"]!["fullTime"]!["away"]! : 0,
                };
                fixtures.Add(fixture);
            }
            return fixtures;
        }
    }
}
