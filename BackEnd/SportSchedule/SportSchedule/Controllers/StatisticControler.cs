using Microsoft.AspNetCore.Mvc;
using SportSchedule.Services.Statistic;

namespace SportSchedule.Controllers
{
    [ApiController]
    [Route("/statistic")]
    public class StatisticControler : Controller
    {
        private readonly IStatisticService _statisticService;
        public StatisticControler(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("{match_id}")]
        public async Task<IActionResult> GetStatisticFixture(int match_id)
        {
            var data = await _statisticService.getStatisticFixtureFrontend(match_id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
