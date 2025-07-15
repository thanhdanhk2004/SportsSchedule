using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SportSchedule.DataTranserferObject.League;

namespace SportSchedule.Services.League
{
    public class LeagueService : ILeagueService
    {
        private readonly HttpClient _httpClient;

        public LeagueService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("FootballAPI");
        }

        public async Task<List<LeagueData>> GetLeagueData()
        {
            var response = await _httpClient.GetAsync("/leagues");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);
            var leagues = new List<LeagueData>();   
            
            foreach(var  item in json["response"])
            {
                var league = new LeagueData
                {
                    Id = (int)item["league"]!["id"]!,
                    Name = (string?)item["league"]!["name"],
                    Description = (string?)item["league"]!["type"],
                    Country = (string?)item["country"]!["name"],
                    Logo = (string?)item["league"]!["logo"],
                    Season = (string?)item["seasons"]!
                        .FirstOrDefault(s => (bool?)s["current"] == true)?["year"]
                };
                leagues.Add(league);
            }
            return leagues;
        }
    }
}
