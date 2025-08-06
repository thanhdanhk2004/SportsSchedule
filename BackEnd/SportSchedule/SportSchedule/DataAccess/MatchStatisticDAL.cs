using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Fixture;
using SportSchedule.DataTranserferObject.Statistic;
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

        public StatisticDTO getMatchStatistic(int match_id)
        {
            try
            {
                var data = (from m in _context.Matches
                            join l in _context.Leagues on m.LeagueId equals l.LeagueId
                            join p in _context.Periods on m.MatchId equals p.MatchId
                            // Doi nha
                            join th in _context.Teams on m.TeamIdHome equals th.TeamId
                            join tmbh in _context.TeamMembers on th.TeamId equals tmbh.TeamId
                            join mbh in _context.Members on tmbh.MemberId equals mbh.MemberId
                            //Doi khach 
                            join ta in _context.Teams on m.TeamIdAway equals ta.TeamId
                            join tmba in _context.TeamMembers on th.TeamId equals tmba.TeamId
                            join mba in _context.Members on tmbh.MemberId equals mba.MemberId
                            join msh in _context.MatchStatictis
                            on new { m.MatchId, th.TeamId } equals new { msh.MatchId, msh.TeamId }
                            join msa in _context.MatchStatictis
                            on new { m.MatchId, ta.TeamId } equals new { msa.MatchId, msa.TeamId }
                            join pm in _context.PlayerMatchModels on m.MatchId equals pm.MatchId
                            where m.MatchId == match_id
                            select new StatisticDTO
                            {
                                LeagueName = l.Name,
                                NameHome = th.Name,
                                NameAway = ta.Name,
                                Time = m.Time.ToString(),
                                LogoHome = th.Logo,
                                LogoAway = ta.Logo,
                                GoalHomeFirst = p.GoalHome,
                                GoalAwayFirst = p.GoalAway,
                                GoalHomeFullTime = msh.Score,
                                GoalAwayFullTime = msa.Score,

                            }).FirstOrDefault();
                           

                return data;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
