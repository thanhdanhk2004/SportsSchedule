using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Fixture;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class TeamDAL
    {
        private readonly ContextDB _context;
        private readonly MatchDAL _matchDAL;
        public TeamDAL(ContextDB context, MatchDAL matchDAL)
        {
            _context = context;
            _matchDAL = matchDAL;
        }

        public void addTeam(FixtureData fixture)
        {
            try
            {
                if(fixture == null) 
                    return;
                TeamModel team_home = new TeamModel
                {
                    TeamId = fixture.HomeId,
                    Name = fixture.HomeName,
                    Logo = fixture.HomeLogo,
                    Country = fixture.Country,
                };
                bool exist_team_home = _context.Teams.Any(t => t.TeamId == team_home.TeamId);
                if(exist_team_home == false)
                {
                    _context.Teams.Add(team_home);
                    _context.SaveChanges();

                    LeagueTeamModel leagueTeam = new LeagueTeamModel
                    {
                        LeagueId = fixture.LeagueId,
                        TeamId = team_home.TeamId,
                    };
                    _context.LeagueTeams.Add(leagueTeam);
                    _context.SaveChanges();
                }
                
                TeamModel team_away = new TeamModel
                {
                    TeamId = fixture.AwayId,
                    Name = fixture.AwayName,
                    Logo = fixture.AwayLogo,
                    Country = fixture.Country,
                };
                bool exist_team_away = _context.Teams.Any(t => t.TeamId == team_away.TeamId);
                if (exist_team_away)
                {
                    _context.Teams.Add(team_away);
                    _context.SaveChanges();

                    LeagueTeamModel leagueTeam = new LeagueTeamModel
                    {
                        LeagueId = fixture.LeagueId,
                        TeamId = team_away.TeamId,
                    };
                    _context.LeagueTeams.Add(leagueTeam);
                    _context.SaveChanges();
                }

                var season = _context.Seasons.FirstOrDefault(s => s.SeasonYear == fixture.Season);
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
                _matchDAL.addFixture(match);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
        }
    }
}
