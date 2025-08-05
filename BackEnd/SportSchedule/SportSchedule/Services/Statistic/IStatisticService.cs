using SportSchedule.DataTranserferObject;
using SportSchedule.DataTranserferObject.Fixture;
using SportSchedule.DataTranserferObject.Statistic;

namespace SportSchedule.Services.Statistic
{
    public interface IStatisticService
    {
        Task<int> getStatisticFixture(string? name_home, string? name_away, DateTime? time, string? league_name, int? home_id, int? away_id, int? match_id, string? Round, List<int> fixture_existed);
        Task<List<StatisticDTO>> getStatisticFixtureFrontend(int match_id);
    }
}
