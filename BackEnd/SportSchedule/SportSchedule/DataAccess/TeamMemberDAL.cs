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
    }
}
