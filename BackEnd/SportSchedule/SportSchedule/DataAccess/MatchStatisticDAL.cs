using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Fixture;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class MatchStatisticDAL
    {
        private readonly ContextDB _context;
        public MatchStatisticDAL(ContextDB context)
        {
            _context = context;
        }

        public void addMatchStatistic(FixtureStatisticData data, int? team_id, int? match_id)
        {
            MatchStatictisModel model = new MatchStatictisModel
            {
                Score = data.Score,
                Possession = data.Possession,
                ShortsOnTaget = data.ShotsOnGoal,
                Corners = data.Corner,
                YellowCard = data.YellowCard,
                RedCard = data.RedCard,
                TeamId = team_id,
                MatchId = match_id
            };
            _context.MatchStatictis.Add(model);
            _context.SaveChanges();
        }

        
    }
}
