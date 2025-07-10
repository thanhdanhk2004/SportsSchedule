using Microsoft.AspNetCore.Mvc;
using SportSchedule.Services;

namespace SportSchedule.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaguesController : Controller
    {
        private readonly FootballApiService _service;

        public LeaguesController(FootballApiService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetLeagues()
        {
            var data = await _service.GetLeaguesAsync();
            if (data == null) return StatusCode(500, "Lỗi khi lấy dữ liệu từ API");

            return Ok(data.response.Select(l => new
            {
                Id = l.league.id,
                Name = l.league.name,
                Type = l.league.type,
                Country = l.country.name,
                Logo = l.league.logo
            }));
        }
    }
}
