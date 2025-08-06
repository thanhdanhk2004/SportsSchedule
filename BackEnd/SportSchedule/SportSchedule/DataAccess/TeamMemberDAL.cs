using SportSchedule.Context;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class TeamMemberDAL
    {
        private readonly ContextDB _context;
        public TeamMemberDAL(ContextDB context)
        {
            _context = context;
        }
        public void addTeamMember(int teamId, int memberId)
        {
            try
            {
                TeamMemberModel model = new TeamMemberModel
                {
                    TeamId = teamId,
                    MemberId = memberId
                };
                _context.TeamMembers.Add(model);
                _context.SaveChanges();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public int getTeamId(int player_id)
        {
            try
            {
                
                var teamId = (int)(from p in _context.Players
                              join m in _context.Members on p.PlayerId equals m.MemberId
                              join tm in _context.TeamMembers on m.MemberId equals tm.MemberId
                              where p.PlayerId == player_id
                              select tm.TeamId).FirstOrDefault()!;
                return teamId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }
    }
}
