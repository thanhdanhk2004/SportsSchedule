using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SportSchedule.Context;
using SportSchedule.DataTranserferObject.League;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace SportSchedule.Services.League
{
    public class LeagueService : ILeagueService
    {
        private readonly HttpClient _httpClient;
        private readonly ContextDB _context;

        public LeagueService(IHttpClientFactory httpClientFactory, ContextDB context)
        {
            _httpClient = httpClientFactory.CreateClient("FootballAPI");
            _context = context;
        }



        public async Task<List<LeagueData>> GetLeagueData()
        {
            List<string> special_leagues = ["Premier League", "V.League 1", "UEFA Champions League", "La Liga", "Serie A", "Bundesliga", "Ligue 1"];
            List<string> countrys = ["England", "Vietnam", "World", "Spain", "Italy", "Germany", "France"];
            var response = await _httpClient.GetAsync("/leagues");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);
            var leagues = new List<LeagueData>();

            foreach (var item in json["response"])
            {
                if (special_leagues.Contains((string?)item["league"]!["name"])
                    && countrys.Contains((string?)item["country"]!["name"]))
                {

                    var seasons = item["seasons"]!
                                .Select(s => s["year"]?.ToString())
                                .Where(y => !string.IsNullOrEmpty(y))
                                .Distinct()
                                .ToList();
                    var league = new LeagueData
                    {
                        Id = (int)item["league"]!["id"]!,
                        Name = (string?)item["league"]!["name"],
                        Description = (string?)item["league"]!["type"],
                        Country = (string?)item["country"]!["name"],
                        Logo = (string?)item["league"]!["logo"],
                        Seasons = seasons
                    };
                    leagues.Add(league);
                }
            }
            return leagues;
        }

        public async Task<List<LeaguesData>> GetLeaguesData()
        {
            var data = await _context.Leagues
                .GroupBy(l => l.Name)
                .Select(l => new LeaguesData
                {
                    Id = l.First().LeagueId,
                    Name = l.First().Name,
                    Logo = l.First().Logo,
                }).ToListAsync();
            return data;
        }
    }
}
