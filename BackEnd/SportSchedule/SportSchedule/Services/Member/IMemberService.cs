using SportSchedule.DataModel;
using SportSchedule.DataTranserferObject.Player;

namespace SportSchedule.Services.Member
{
    public interface IMemberService
    {
        Task getMemberService(int fixture_id, int team_home_id, int team_away_id, int match_id);
        Task addInfoCoach(int coad_id);
        Task<InfoDataMember> getDataPlayer(int player_id);
        Task<PlayerInfoDTOFE> getPlayerInfo(int player_id);
    }
}
