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
    }
}
