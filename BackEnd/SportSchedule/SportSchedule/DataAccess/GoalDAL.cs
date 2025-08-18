using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Goal;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class GoalDAL
    {
        private readonly ContextDB _context;
        private readonly MemberDAL _memberDAL;
        public GoalDAL(ContextDB context, MemberDAL memberDAL)
        {
            _context = context;
            _memberDAL = memberDAL;
        }
        public void addGoal(GoalDTO goal)
        {
            try
            {
                if(goal != null)
                {
                    GoalModel model = new GoalModel
                    {
                        GoalType = goal.GoalType,
                        PlayerId = _memberDAL.isExistedMember(goal.PlayerId ?? 0) == true ? goal.PlayerId:null,
                        TeamId = goal.TeamId,
                        MatchId = goal.MatchId,
                        GoalTime = goal.GoalTime,
                    };
                    _context.Goals.Add(model);
                    _context.SaveChanges();
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
