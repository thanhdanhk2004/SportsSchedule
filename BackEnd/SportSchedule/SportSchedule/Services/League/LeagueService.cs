using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SportSchedule.Context;
using SportSchedule.DataModel;
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


        public async Task<List<LeaguesData>> GetLeaguesDataFrontEnd()
        {
            List<string> leagues = ["La Liga", "Premier League", "UEFA Champions League", "Ligue 1", "Bundesliga", "Serie A", "FIFA World Cup"];
            var data = await _context.Leagues
                .Where(l=> leagues.Contains(l.Name!) && l.Country != "Brazil")
                .Select(l => new LeaguesData
                {
                    Id = l.LeagueId,
                    Name = l.Name,
                    Logo = l.Logo,
                }).ToListAsync();
            return data;
        }

        public async Task<List<InfoDataLeagueTeam>> getLeagueTeamData(string league, string season)
        {
            var reponse = await _httpClient.GetAsync($"competitions/{league}/teams?season={season}");
            reponse.EnsureSuccessStatusCode();

            var content = await reponse.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);
            List<InfoDataLeagueTeam> list = new List<InfoDataLeagueTeam>();

            foreach( var item in json["teams"]!)
            {
                InfoDataLeagueTeam leagueTeam = new InfoDataLeagueTeam
                {
                    LeagueId = (int)json["competition"]?["id"]!,
                    TeamId = (int)item["id"]!,
                    NameHome = (string)item["venue"]!
                };
                list.Add(leagueTeam);
            }
            return list;
        }
    }
}
