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
        public async Task<IActionResult> GetFixture(string date)
        {
            var fixtures = await _fixtureService.GetFixtureDataFrontendsAsync(date);
            if(fixtures == null)
            {
                return NotFound();
            }
            return Ok(fixtures);
        }

        [HttpGet("{fixture_id}")]
        public async Task<IActionResult> GetInfoFixture(int fixture_id, string date)
        {
            var fixture = await _fixtureService.GetInfoFixtureAsync(fixture_id, date);
            if (fixture == null)
                return BadRequest();
            return Ok(fixture);
        }
    }
}
