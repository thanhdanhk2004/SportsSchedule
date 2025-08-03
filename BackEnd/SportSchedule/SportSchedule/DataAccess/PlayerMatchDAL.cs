using SportSchedule.Context;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class PlayerMatchDAL
    {
        private readonly ContextDB _context;
        public PlayerMatchDAL(ContextDB context)
        {
            _context = context;
        }

        public void addPlayerMatch(int match_id, int player_id, bool status)
        {
            try
            {
                PlayerMatchModel playerMatch = new PlayerMatchModel
                {
                    MatchId = match_id,
                    PlayerId = player_id,
                    Status = status
                };
                _context.PlayerMatchModels.Add(playerMatch);
                _context.SaveChanges();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
