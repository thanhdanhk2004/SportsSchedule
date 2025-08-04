using Microsoft.EntityFrameworkCore;
using SportSchedule.DataAccess;
using SportSchedule.DataModel;
using SportSchedule.Services.Member;
using SportSchedule.Services.Statistic;
using System.Globalization;

namespace SportSchedule.Context.Seed
{
    public class DataSeedStatistic
    {        
        public static async Task SeenDataStatistic(ContextDB _context, IStatisticService _statisticService, IMemberService _memberService)
        {
            _context.Database.Migrate();
            DateTime dateNow = TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified), TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));

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
                           .Where(x => x.Match.Time.Value.Date <= dateNow.Date)
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

            int fixture_existed = 0;
            foreach ( var response in responses )
            {
                DateTime timeFixture = response.Time ?? DateTime.MinValue;
                if (dateNow >= timeFixture.AddHours(3) &&
                    !_context.MatchStatictis.Any(ms => ms.MatchId == response.MatchId))
                {
                    int fixture_id = await _statisticService.getStatisticFixture(response.NameHome, response.NameAway,
                       response.Time, response.LeagueName, response.HomeId, response.AwayId,
                       response.MatchId, response.Round, fixture_existed);
                    if(fixture_id != 0)
                    {
                        await _memberService.getMemberService(fixture_id, response.HomeId ?? 0, response.AwayId ?? 0, response.MatchId ?? 0);
                    }
                    fixture_existed = fixture_id;
                }
            }
        }
    }
}
