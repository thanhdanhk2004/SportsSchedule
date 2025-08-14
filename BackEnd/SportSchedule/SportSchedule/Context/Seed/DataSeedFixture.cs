using Microsoft.EntityFrameworkCore;
using SportSchedule.DataModel;
using SportSchedule.DataTranserferObject.Fixture;
using SportSchedule.DataTranserferObject.League;
using SportSchedule.Model;
using SportSchedule.Services.Fixtures;
using SportSchedule.Services.League;
using System.Linq;
using System.Threading.Tasks;

namespace SportSchedule.Context.Seed
{
    public class DataSeedFixture
    {
        public static async Task SeedingData(ContextDB _context, ILeagueService _leagueService, IFixturesService _fixtureSevice)
        {
            _context.Database.Migrate();
            if(!_context.Leagues.Any())
            {
                List<LeagueData> reponse = await _leagueService.GetLeagueData();
                foreach(var item in reponse)
                {
                    LeagueModel league = new LeagueModel
                    {
                        LeagueId = item.Id,
                        Name = item.Name,
                        Country = item.Country,
                        Logo = item.Logo,
                        Code = item.Code,
                    };
                    _context.Leagues.Add(league);
                    _context.SaveChanges();
                    for(int i = 2020; i < 2026; i++)
                    {
                        var season = _context.Seasons.Where(s => s.SeasonYear == i.ToString()).FirstOrDefault();

                        if(season == null)
                        {
                            SeasonModel season_model = new SeasonModel
                            {
                                SeasonYear = i.ToString(),
                            };
                            _context.Seasons.Add(season_model);
                            _context.SaveChanges();
                            LeagueSeasonModel league_season = new LeagueSeasonModel
                            {
                                LeagueId = league.LeagueId,
                                SeasonId = season_model.SeasonId,
                            };
                            _context.LeagueSeasons.Add(league_season);
                            _context.SaveChanges();
                        }
                        else
                        {
                            LeagueSeasonModel league_season = new LeagueSeasonModel
                            {
                                LeagueId = league.LeagueId,
                                SeasonId = season.SeasonId,
                            };
                            _context.LeagueSeasons.Add(league_season);
                            _context.SaveChanges();
                        }
                    }
                }
            }

            if (!_context.Matches.Any())
            {
                List<FixtureData> fixtures = await _fixtureSevice.GetFixturesAsync();
                
                foreach(FixtureData fixture in fixtures)
                {
                    TeamModel team_home = new TeamModel
                    {
                        TeamId = fixture.HomeId,
                        Name = fixture.HomeName,
                        Logo = fixture.HomeLogo,
                        Country = fixture.Country,
                    };
                    var exist_team_home = _context.Teams.FirstOrDefault(t => t.TeamId == team_home.TeamId);

                    //Them doi neu chua ton tai
                    if(exist_team_home == null)
                    {
                        _context.Teams.Add(team_home);
                        _context.SaveChanges();
                    }
                    TeamModel team_away = new TeamModel
                    {
                        TeamId = fixture.AwayId,
                        Name = fixture.AwayName,
                        Logo = fixture.AwayLogo,
                        Country = fixture.Country,
                    };
                    var exist_team_away = _context.Teams.FirstOrDefault(t => t.TeamId == team_away.TeamId);
                    if (exist_team_away == null)
                    {
                        _context.Teams.Add(team_away);
                        _context.SaveChanges();
                    }

                    var season = _context.Seasons.FirstOrDefault(s => s.SeasonYear == fixture.Season);
                                    
                    //Them tran dau
                    MatchModel match = new MatchModel
                    {
                        MatchId = fixture.FixtureId,
                        Venue = fixture.Venue,
                        Time = fixture.Date,
                        TeamIdHome = team_home.TeamId,
                        TeamIdAway = team_away.TeamId,
                        SeasonId = season!.SeasonId,
                        LeagueId = fixture.LeagueId,
                        Round = fixture.Round,
                    };
                    _context.Matches.Add(match);
                    _context.SaveChanges();
                }
            }

            if (!_context.LeagueTeams.Any())
            {
                var leagues = _context.Leagues.Select(l => l.Name).ToList();
                var data = new Dictionary<string, string>
                {
                    { "Premier League", "PL"},
                    {"Primera Division","PD" },
                    {"Campeonato Brasileiro Série A", "BSA " },
                    {"Ligue 1","FL1" },
                    {"Bundesliga","BL1 " },
                    {"Serie A","SA" }
                };
                foreach (var league in leagues)
                {
                    List<InfoDataLeagueTeam> list = await _leagueService.getLeagueTeamData(data[league], "2025");
                    foreach (var item in list)
                    {
                        LeagueTeamModel model = new LeagueTeamModel
                        {
                            LeagueId = item.LeagueId,
                            TeamId = item.TeamId,
                        };
                        var team = _context.Teams.Where(t => t.TeamId == item.TeamId).FirstOrDefault();
                        if (team != null)
                        {
                            team.NameHome = item.NameHome;
                        }
                        _context.Teams.Update(team);
                        _context.SaveChanges();
                        _context.LeagueTeams.Add(model);
                        _context.SaveChanges();
                    }
                }
            }
        }
    }
}
