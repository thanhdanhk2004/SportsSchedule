using SportSchedule.DataTranserferObject.League;

namespace SportSchedule.Services.League
{
    public interface ILeagueService
    {
         Task<List<LeagueData>> GetLeagueData();
         Task<List<LeaguesData>> GetLeaguesDataFrontEnd();
    }
}
