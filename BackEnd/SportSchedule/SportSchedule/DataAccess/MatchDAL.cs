using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Fixture;

namespace SportSchedule.DataAccess
{
    public class MatchDAL
    {
        private readonly ContextDB _context;
        public MatchDAL(ContextDB context)
        {
            _context = context;
        }

        public List<FixtureDataFrontend> getFixturesDAL(DateTime time, DateTime nextTime)
        {
            try
            {
                var data = (from m in _context.Matches
                            join th in _context.Teams on m.TeamIdHome equals th.TeamId
                            join tw in _context.Teams on m.TeamIdAway equals tw.TeamId
                            join l in _context.Leagues on m.LeagueId equals l.LeagueId
                            join msh in _context.MatchStatictis  // Đội nhà
                            on new { MatchId = m.MatchId, TeamId = th.TeamId }
                            equals new { msh.MatchId, msh.TeamId } into mshGroup
                            from home in mshGroup.DefaultIfEmpty()

                            join msw in _context.MatchStatictis//Đội khách
                            on new { MatchId = m.MatchId, TeamId = tw.TeamId }
                            equals new { msw.MatchId, msw.TeamId } into mswGroup
                            from away in mswGroup.DefaultIfEmpty()

                            where m.Time >= time && m.Time < nextTime
                            select new FixtureDataFrontend
                            {
                                LeagueName = l.Name,
                                LeagueLogo = l.Logo,
                                MatchId = m.MatchId,
                                NameHome = th.Name,
                                NameAway = tw.Name,
                                Time = m.Time.ToString(),
                                LogoHome = th.Logo,
                                LogoAway = tw.Logo,
                                HomeId = th.TeamId,
                                AwayId = tw.TeamId,
                                GoalHomeFirst = (_context.Periods.Where(pf => pf.Name == "first" && pf.MatchId == m.MatchId).Select(pf => pf.GoalHome)).FirstOrDefault(),
                                GoalAwayFirst = (_context.Periods.Where(ps => ps.Name == "second" && ps.MatchId == m.MatchId).Select(ps => ps.GoalHome)).FirstOrDefault(),
                                GoalHomeFullTime = home.Score,
                                GoalAwayFullTime = away.Score
                            }).ToList();
                return data;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
