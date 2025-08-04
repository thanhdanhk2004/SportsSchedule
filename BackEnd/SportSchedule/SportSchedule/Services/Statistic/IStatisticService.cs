using SportSchedule.DataTranserferObject.Fixture;

namespace SportSchedule.Services.Statistic
{
    public interface IStatisticService
    {
        Task<int> getStatisticFixture(string? name_home, string? name_away, DateTime? time, string? league_name, int? home_id, int? away_id, int? match_id, string? Round, int fixture_existed);
    }
}
