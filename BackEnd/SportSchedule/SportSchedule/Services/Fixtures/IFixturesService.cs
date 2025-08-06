using SportSchedule.DataTranserferObject.Fixture;

namespace SportSchedule.Services.Fixtures
{
    public interface IFixturesService
    {
        Task<List<FixtureData>> GetFixturesAsync();
        Task<List<FixtureDataFrontend>> GetFixtureDataFrontendsAsync(string date);
        Task<FixtureDataFrontend> GetInfoFixtureAsync(int id, string date);
    }
}
