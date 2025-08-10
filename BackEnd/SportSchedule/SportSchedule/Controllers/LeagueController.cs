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
            var data = await _leagueService.GetLeaguesDataFrontEnd();
            if (data == null) 
                return BadRequest(new {message = "Yêu cầu kiểm tra mạng"} );
            return Ok(new { leagues = data });
        }
    }
}
