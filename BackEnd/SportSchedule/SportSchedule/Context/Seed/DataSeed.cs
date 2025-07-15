using Microsoft.EntityFrameworkCore;
using SportSchedule.DataTranserferObject.League;
using SportSchedule.Model;
using SportSchedule.Services.League;
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
                    SeasonModel season = new SeasonModel
                    {
                        SeasonId = item.Id.ToString(),
                        SeasonYear = item.Season
                    };
                    _context.Add(season);
                    _context.SaveChanges();

                    LeagueModel leagueModel = new LeagueModel
                    {
                        LeagueId = item.Id.ToString(),
                        Name = item.Name,
                        Country = item.Country,
                        Logo = item.Logo,
                        SeasonId = season.SeasonId,
                    };
                    _context.Add(leagueModel);
                    _context.SaveChanges();
                }
            }
        }
    }
}
