using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Goal;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class GoalDAL
    {
        private readonly ContextDB _context;
        public GoalDAL(ContextDB context)
        {
            _context = context;
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
                        PlayerId = goal.PlayerId,
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
