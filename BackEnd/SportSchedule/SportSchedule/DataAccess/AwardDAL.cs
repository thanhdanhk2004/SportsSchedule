using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Award;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class AwardDAL
    {
        private readonly ContextDB _context;
        public AwardDAL(ContextDB context)
        {
            _context = context;
        }

        public List<AwardDTOFEAdmin> getGuessExactly(int matchId)
        {
            try
            {
                if (matchId == null)
                    return null!;
                var data = (from g in _context.Guesses
                            join u in _context.Users on g.UserId equals u.UserId
                            join m in _context.Matches on g.MatchId equals m.MatchId
                            join th in _context.Teams on m.TeamIdHome equals th.TeamId
                            join ta in _context.Teams on m.TeamIdAway equals ta.TeamId
                            join msh in _context.MatchStatictis
                            on new { m.MatchId, th.TeamId } equals new { msh.MatchId, msh.TeamId }
                            join msa in _context.MatchStatictis
                            on new { m.MatchId, ta.TeamId } equals new { msa.MatchId, msa.TeamId }
                            where m.MatchId == matchId && g.PredictHomeScore == msh.Score 
                            && g.PredictAwayScore == msa.Score
                            select new AwardDTOFEAdmin
                            {
                                GuessId = g.GuessId,
                                UserId = u.UserId,
                                Email = u.Email,
                                NameHome = th.Name,
                                NameAway = ta.Name,
                                ScoreHome = msh.Score,
                                ScoreAway = msa.Score,
                                ScorePredictHome = g.PredictHomeScore,
                                ScorePredictAway = g.PredictAwayScore,
                            }).ToList();
                return data;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null!;
            }
        }

        public bool addAward(int guessId)
        {
            try
            {
                if (guessId == null)
                    return false;
                AwardModel award = new AwardModel
                {
                    GuessId = guessId,
                    Description = "Phần quà 5 xị",
                    Status = false,
                    TimeAward = DateTime.UtcNow,
                };
                _context.Awards.Add(award);
                _context.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool updateAward(int awardId)
        {
            try
            {
                if (awardId == null)
                    return false;
                var award = _context.Awards.FirstOrDefault(a => a.AwardId == awardId);
                if (award == null)
                    return false;
                award.Status = true;
                award.TimeAward = DateTime.UtcNow;
                _context.Awards.Update(award);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
