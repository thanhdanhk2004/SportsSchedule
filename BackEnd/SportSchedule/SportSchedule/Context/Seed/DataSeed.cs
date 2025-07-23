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
                int j = 0;
                foreach(var item in reponse)
                {
                    LeagueModel league = new LeagueModel
                    {
                        Name = item.Name,
                        Country = item.Country,
                        Logo = item.Logo,
                    };
                    _context.Leagues.Add(league);
                    _context.SaveChanges();
                    for(int i = 0; i < item.Seasons?.Count; i++)
                    {
                        var season = _context.Seasons.Where(s => s.SeasonYear == item.Seasons[i]).FirstOrDefault();

                        if(season == null)
                        {
                            SeasonModel season_model = new SeasonModel
                            {
                                SeasonYear = item.Seasons[i],
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
