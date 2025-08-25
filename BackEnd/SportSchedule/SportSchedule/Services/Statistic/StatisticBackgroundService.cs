
using SportSchedule.Context;
using SportSchedule.DataModel;
using SportSchedule.Services.Member;
using SportSchedule.Services.Ranking;

namespace SportSchedule.Services.Statistic
{
    public class StatisticBackgroundService : BackgroundService
    {
        private readonly ILogger<StatisticBackgroundService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public StatisticBackgroundService(ILogger<StatisticBackgroundService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Sending data at: { time}", DateTime.Now);
                using(var scope = _serviceScopeFactory.CreateScope())
                {
                    ContextDB _context = scope.ServiceProvider.GetService<ContextDB>()!;
                    var _statisticService = scope.ServiceProvider.GetRequiredService<IStatisticService>();
                    var _memberService = scope.ServiceProvider.GetRequiredService<IMemberService>();
                    var _rankingService = scope.ServiceProvider.GetRequiredService<IRankingService>();
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
                                   .Select(x => new InfoDataStatistic
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
                    foreach (var response in responses)
                    {
                        DateTime timeFixture = response.Time ?? DateTime.MinValue;

                        if (dateNow >= timeFixture.AddHours(3) &&
                            !_context.MatchStatictis.Any(ms => ms.MatchId == response.MatchId)
                            && response.LeagueName == "Premier League")
                        {
                            int fixture_id = await _statisticService.getStatisticFixture(response.NameHome, response.NameAway,
                               timeFixture.AddHours(-7).Day >= dateNow.Day ? response.Time : dateNow.AddDays(-1), response.LeagueName, response.HomeId, response.AwayId,
                               response.MatchId, response.Round, fixtures_existed, response.Time);

                            if (fixture_id != 0)
                            {
                                await _memberService.getMemberService(fixture_id, response.HomeId ?? 0, response.AwayId ?? 0, response.MatchId ?? 0);
                                await _statisticService.getEventFixture(fixture_id, response.MatchId ?? 0);
                                await _rankingService.updateRankings(response.MatchId ?? 0);
                            }
                            fixtures_existed.Add(fixture_id);
                        }
                    }
                }
                await Task.Delay(TimeSpan.FromHours(8), stoppingToken);
            }
        }
    }
}
