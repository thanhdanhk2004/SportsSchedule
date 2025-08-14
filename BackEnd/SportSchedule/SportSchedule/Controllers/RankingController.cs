using Microsoft.AspNetCore.Mvc;
using SportSchedule.Services.Ranking;

namespace SportSchedule.Controllers
{
    [ApiController]
    [Route("/ranking")]
    public class RankingController : Controller
    {
        private readonly IRankingService _rankingService;
        public RankingController(IRankingService rankingService)
        {
            _rankingService = rankingService;
        }

        [HttpGet]
        public async Task<IActionResult> getRanking(int league_id, string season)
        {
            var data = await _rankingService.getRankings(league_id, season);
            if(data == null) 
                return NotFound();
            return Ok(data);
        }
    }
}
