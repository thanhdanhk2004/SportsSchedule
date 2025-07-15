using Microsoft.AspNetCore.Mvc;
using SportSchedule.Services.League;

namespace SportSchedule.Controllers
{
    [ApiController]
    [Route("/league")]
    public class LeagueController : Controller
    {
        private readonly ILeagueService _leagueService;
        public LeagueController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLeague()
        {
            var leagues = await _leagueService.GetLeagueData();
            return Ok(leagues);
        }
    }
}
