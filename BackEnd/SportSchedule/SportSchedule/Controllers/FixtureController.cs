using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportSchedule.DataTranserferObject.Fixture;
using SportSchedule.Services.Fixtures;

namespace SportSchedule.Controllers
{
    [ApiController]
    [Route("/fixture")]
    public class FixtureController : Controller
    {
        private readonly IFixturesService _fixtureService;
        public FixtureController(IFixturesService fixtureService)
        {
            _fixtureService = fixtureService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFixtureByDate(string date)
        {
            var data = await _fixtureService.GetFixturesByDateDataFrontendsAsync(date);
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("{league_id}/{page}")]
        public async Task<IActionResult> getInfoFixtureByLeague(int league_id, int page=1)
        {
            var data = await _fixtureService.GetFixtruesByLeagueDataFrontendAsync(league_id, page);
            if(data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpGet("/fixtures/predict/{page}")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> getFixturesToPredict(int page)
        {
            var data = await _fixtureService.getFixturesAdmin(page);
            if( data != null )
                return Ok(data);
            return NotFound();
        }

        [HttpPatch("/update/{matchId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> updateStatusPredict(int matchId, bool status)
        {
            bool result = await _fixtureService.updateStatusPredict(matchId, status);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}
