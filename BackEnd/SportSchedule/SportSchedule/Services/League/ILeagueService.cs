using SportSchedule.DataModel;
using SportSchedule.DataTranserferObject.League;

namespace SportSchedule.Services.League
{
    public interface ILeagueService
    {
         Task<List<LeagueData>> GetLeagueData();
         Task<List<LeagueDTOFE>> GetLeaguesDataFrontEnd();
         Task<List<InfoDataLeagueTeam>> getLeagueTeamData(string league, string season);
    }
}
