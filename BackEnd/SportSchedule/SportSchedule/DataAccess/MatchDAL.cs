using Microsoft.AspNetCore.Mvc.RazorPages;
using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Fixture;
using SportSchedule.DataTranserferObject.Page;

namespace SportSchedule.DataAccess
{
    public class MatchDAL
    {
        private readonly ContextDB _context;
        public MatchDAL(ContextDB context)
        {
            _context = context;
        }

        //Lay cac tran dau theo ngay thi dau
        public List<FixtureDataFrontend> getFixturesByDateDAL(DateTime time, DateTime nextTime)
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
                                LeagueId = l.LeagueId,
                                LeagueName = l.Name,
                                Round = m.Round,
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

        //Lay cac tran dau theo giai
        public List<FixtureDataFrontend> getFixtrueByLeagueDAL(int league_id, int page)
        {
            try
            {
                var result = (from m in _context.Matches
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

                            where l.LeagueId == league_id
                            select new FixtureDataFrontend
                            {
                                LeagueId = l.LeagueId,
                                LeagueName = l.Name,
                                Round = m.Round,
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
                                GoalAwayFullTime = away.Score,
                            }).ToList();
                
                int number_round = result.GroupBy(r => r.Round).Count();
                int number_fixture_a_round = result.Where(r => r.Round == page.ToString()).Count();
                int number_skip = (page - 1) * number_fixture_a_round;
                var data = result.Skip(number_skip).Take(number_fixture_a_round).ToList();
                data[0].NumberRound = number_round;
                return (List<FixtureDataFrontend>)data;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
