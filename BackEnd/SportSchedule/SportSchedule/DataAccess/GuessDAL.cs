using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Guess;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class GuessDAL
    {
        private readonly ContextDB _context;
        private readonly UserDAL _userDAL;
        public GuessDAL(ContextDB context, UserDAL userDAL)
        {
            _context = context;
            _userDAL = userDAL;
        }

        //Them du doan
        public bool addGuess(GuessDTO guess, string username, int matchId)
        {
            try
            {
                if(guess == null) 
                    return false;
                bool guessExisted = _context.Guesses
                    .Any(g => g.MatchId == matchId && g.UserId == _userDAL.getUserId(username));
                if (guessExisted)
                    return false;
                GuessModel model = new GuessModel
                {
                    GuessTime = DateTime.UtcNow,
                    PredictHomeScore = guess.PredictHomeScore,
                    PredictAwayScore = guess.PredictAwayScore,
                    MatchId = matchId,
                    UserId = _userDAL.getUserId(username),
                };
                _context.Guesses.Add(model);
                _context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        //Lay cac tran dau du doan
        public List<GuessDTOFE> getMatchsGuess()
        {
            try
            {
                var data = (from m in _context.Matches
                            join th in _context.Teams on m.TeamIdHome equals th.TeamId
                            join ta in _context.Teams on m.TeamIdAway equals ta.TeamId
                            where m.Predict == true && m.Time >= DateTime.UtcNow
                            select new GuessDTOFE
                            {
                                MatchId = m.MatchId,
                                TeamNameHome = th.Name,
                                TeamNameAway = ta.Name,
                                MatchTime = m.Time.ToString(),
                                LogoNameHome = th.Logo,
                                LogoNameAway = ta.Logo,
                                RepresentativeHome = (from tmh in _context.TeamMembers
                                                      join mh in _context.Members on tmh.MemberId equals mh.MemberId
                                                      where tmh.TeamId == th.TeamId && mh.Image != null
                                                      select mh.Image
                                                      ).FirstOrDefault(),
                                RepresentativeAway = (from tma in _context.TeamMembers
                                                      join ma in _context.Members on tma.MemberId equals ma.MemberId
                                                      where tma.TeamId == ta.TeamId && ma.Image != null
                                                      select ma.Image
                                                      ).FirstOrDefault(),
                            }).ToList();
                return data;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
