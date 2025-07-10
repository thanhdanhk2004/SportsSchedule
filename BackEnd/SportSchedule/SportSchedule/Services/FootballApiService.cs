using SportSchedule.DataTranserferObject;
using System.Text.Json;

namespace SportSchedule.Services
{
    public class FootballApiService
    {
        private readonly HttpClient _client;

        public FootballApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("FootballAPI");
        }

        public async Task<LeagueResponse?> GetLeaguesAsync()
        {
            var response = await _client.GetAsync("leagues");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<LeagueResponse>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            return null;
        }
    }
}
