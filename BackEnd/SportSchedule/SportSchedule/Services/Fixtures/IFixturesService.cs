using SportSchedule.DataTranserferObject.Fixture;

namespace SportSchedule.Services.Fixtures
{
    public interface IFixturesService
    {
        Task<List<FixtureData>> GetFixturesAsync();
        Task<List<FixtureDataFrontend>> GetFixturesByDateDataFrontendsAsync(string date);
        Task<List<FixtureDataFrontend>> GetFixtruesByLeagueDataFrontendAsync(int league_id, int page);
    }
}
