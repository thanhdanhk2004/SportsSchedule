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
            _httpClient = httpClientFactory.CreateClient("FootballData");
            _context = context;
        }

        public async Task<List<LeagueData>> GetLeagueData()
        {
            var response = await _httpClient.GetAsync("competitions");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);
            var leagues = new List<LeagueData>();
            foreach (var item in json["competitions"]!)
            {
                var league = new LeagueData
                {
                    Id = (int)item["id"]!,
                    Name = (string?)item["name"],
                    Description = (string?)item["type"],
                    Country = (string?)item["area"]!["name"],
                    Logo = (string?)item["emblem"]!,
                    Code = (string?)item["code"]!,
                };
                leagues.Add(league);
            }
            return leagues;
        }
        public async Task<List<LeaguesData>> GetLeaguesData()
        {
            List<string> leagues = ["European Championship", "Premier League", "UEFA Champions League", "Ligue 1", "Bundesliga", "Serie A", "FIFA World Cup"];
            var data = await _context.Leagues
                .Where(l=> leagues.Contains(l.Name!))
                .Select(l => new LeaguesData
                {
                    Id = l.LeagueId,
                    Name = l.Name,
                    Logo = l.Logo,
                }).ToListAsync();
            return data;
        }
    }
}
