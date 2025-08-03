using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Fixture;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class PeriodDAL
    {
        private readonly ContextDB _context;
        public PeriodDAL(ContextDB context)
        {
            _context = context;
        }

        public void addPeriod(PeriodData period, int? matchId)
        {
            try
            {
                PeriodModel model = new PeriodModel
                {
                    Name = period.Name,
                    GoalHome = period.GoalHome,
                    GoalAway = period.GoalAway,
                    MatchId = matchId,
                    Time = DateTimeOffset.FromUnixTimeSeconds(period.Time).UtcDateTime
                };
                _context.Periods.Add(model);
                _context.SaveChanges();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
