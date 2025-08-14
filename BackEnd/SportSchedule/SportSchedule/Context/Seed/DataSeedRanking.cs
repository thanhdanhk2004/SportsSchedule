using Microsoft.EntityFrameworkCore;
using SportSchedule.Services.Ranking;

namespace SportSchedule.Context.Seed
{
    public class DataSeedRanking
    {
        public static async Task SeedRanking(ContextDB _context,IRankingService _rankingService)
        {
            _context.Database.Migrate();
            if(!_context.Rankings.Any())
            {
                await _rankingService.addRankings();
            }
        }
    }
}
