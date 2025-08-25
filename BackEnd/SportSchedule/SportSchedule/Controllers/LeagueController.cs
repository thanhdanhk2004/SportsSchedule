using Microsoft.AspNetCore.Authorization;
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

        //Chuc nang admin
        [HttpGet("/admin/leagues")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> getLeaguesAdmin()
        {
            var data = await _leagueService.getLeaguesAdmin();
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpDelete("/admin/leagues/delete/{leagueId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> deleteLeague(int leagueId)
        {
            bool resutl = await _leagueService.deleteLeague(leagueId);
            if (resutl)
                return Ok();
            return BadRequest();
        }
    }
}
