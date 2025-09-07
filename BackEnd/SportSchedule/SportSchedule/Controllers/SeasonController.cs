using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportSchedule.Services.Season;

namespace SportSchedule.Controllers
{
    [ApiController]
    public class SeasonController : Controller
    {
        private readonly ISeasonService _seasonService;
        public SeasonController(ISeasonService seasonService)
        {
            _seasonService = seasonService;
        }

        [HttpPost("admin/season/add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> addSeason()
        {
            bool result = await _seasonService.addSeason();
            if (result == false)
                return BadRequest();
            return Ok();
        }
    }
}
