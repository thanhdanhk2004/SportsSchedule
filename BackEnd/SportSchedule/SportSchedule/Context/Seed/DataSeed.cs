using Microsoft.EntityFrameworkCore;
using SportSchedule.DataTranserferObject.League;
using SportSchedule.Model;
using SportSchedule.Services.League;
using System.Linq;
using System.Threading.Tasks;

namespace SportSchedule.Context.Seed
{
    public class DataSeed
    {
        public static async Task SeedingData(ContextDB _context, ILeagueService _leagueService)
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
        }
    }
}
