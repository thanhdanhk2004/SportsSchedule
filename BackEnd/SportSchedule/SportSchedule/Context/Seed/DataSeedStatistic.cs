using Microsoft.EntityFrameworkCore;
using SportSchedule.DataAccess;
using SportSchedule.DataModel;
using SportSchedule.Services.Member;
using SportSchedule.Services.Ranking;
using SportSchedule.Services.Statistic;
using System.Globalization;

namespace SportSchedule.Context.Seed
{
    public class DataSeedStatistic
    {        
        public static async Task SeenDataStatistic(ContextDB _context, IStatisticService _statisticService, IMemberService _memberService, IRankingService _rankingService)
        {
            _context.Database.Migrate();
            DateTime dateNow = DateTime.Now;

            var responses = (from m in _context.Matches
                           join th in _context.Teams on m.TeamIdHome equals th.TeamId
                           join ta in _context.Teams on m.TeamIdAway equals ta.TeamId                          
                           join l in _context.Leagues on m.LeagueId equals l.LeagueId
                           select new
                           {
                               Match = m,
                               TeamHome = th,
                               TeamAway = ta,
                               League = l
                           }).AsEnumerable()
                           .Where(x => x.Match.Time.Value.Date == dateNow.Date || x.Match.Time.Value.Date == dateNow.Date.AddDays(-1))
                           .Select( x => new InfoDataStatistic
                           {
                               Time = x.Match.Time,
                               NameHome = x.TeamHome.Name,
                               NameAway = x.TeamAway.Name,
                               LeagueName = x.League.Name,
                               HomeId = x.TeamHome.TeamId,
                               AwayId = x.TeamAway.TeamId,
                               MatchId = x.Match.MatchId,
                               Round = "Regular Season - " + x.Match.Round,
                           }).ToList();

           

            List<int> fixtures_existed = new List<int>();
            foreach (var response in responses )
            {
                DateTime timeFixture = response.Time ?? DateTime.MinValue;

                if (dateNow >= timeFixture.AddHours(3) &&
                    !_context.MatchStatictis.Any(ms => ms.MatchId == response.MatchId))
                {
                    int fixture_id = await _statisticService.getStatisticFixture(response.NameHome, response.NameAway,
                       timeFixture.AddHours(-7).Day >= dateNow.Day?response.Time : dateNow.AddDays(-1), response.LeagueName, response.HomeId, response.AwayId,
                       response.MatchId, response.Round, fixtures_existed, response.Time);

                    if(fixture_id != 0)
                    {
                        await _memberService.getMemberService(fixture_id, response.HomeId ?? 0, response.AwayId ?? 0, response.MatchId ?? 0);
                        await _statisticService.getEventFixture(fixture_id, response.MatchId ?? 0);
                        await _rankingService.updateRankings(response.MatchId ?? 0);
                    }
                    fixtures_existed.Add(fixture_id);
                }
            }
        }
    }
}
