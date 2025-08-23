using SportSchedule.DataTranserferObject.Fixture;

namespace SportSchedule.Services.Fixtures
{
    public interface IFixturesService
    {
        Task<List<FixtureData>> GetFixturesAsync();
        Task<List<FixtureDataFrontend>> GetFixturesByDateDataFrontendsAsync(string date);
        Task<List<FixtureDataFrontend>> GetFixtruesByLeagueDataFrontendAsync(int league_id, int page);

        //Chuc nang admin
        Task<bool> updateStatusPredict(int match_id, bool status);
        Task<List<FixtureDTOFEAdmin>> getFixturesAdmin(int page);
    }
}
