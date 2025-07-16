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

                for(int i = 0; i < reponse[0].Seasons.Count; i++)
                {
                    SeasonModel season = new SeasonModel
                    {
                        SeasonId = "S" + i.ToString(),
                        SeasonYear = reponse[0].Seasons[i]
                    };
                    _context.Add(season);
                    _context.SaveChanges();
                }

                int j = 0;
                foreach(var item in reponse)
                {
                    for (int i = 0; i < _context.Seasons.Count(); i++)
                    {
                        if(item.Seasons.Contains(_context.Seasons.Where(s => s.SeasonId == "S"+i.ToString()).Select(s => s.SeasonYear).FirstOrDefault()))
                        {
                            LeagueModel leagueModel = new LeagueModel
                            {
                                LeagueId = "League " + j.ToString(),
                                Name = item.Name,
                                Country = item.Country,
                                Logo = item.Logo,
                                SeasonId = "S" + i.ToString()
                            };
                            _context.Add(leagueModel);
                            _context.SaveChanges();
                            j++;
                        }
                        
                    }
                }
            }
        }
    }
}
