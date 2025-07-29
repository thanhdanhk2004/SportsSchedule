using Microsoft.AspNetCore.Mvc;
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

    }
}
