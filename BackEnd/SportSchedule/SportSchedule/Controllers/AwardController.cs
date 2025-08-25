using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportSchedule.Services.Award;

namespace SportSchedule.Controllers
{
    [ApiController]
    public class AwardController : Controller
    {
        private readonly IAwardService _awardService;
        public AwardController(IAwardService awardService)
        {
            _awardService = awardService;
        }

        [HttpPost("/admin/award/add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> addAward(int guessId)
        {
            bool result = await _awardService.addAward(guessId);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpGet("/admin/guess/exactly/{matchId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> getGuessExactly(int matchId)
        {
            var data = await _awardService.getGuessExactly(matchId);
            if(data == null)    
                return NotFound();
            return Ok(data);
        }

        [HttpGet("/admin/list/award")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> getListAward()
        {
            var data = await _awardService.getListAward();
            if (data == null)
                return NotFound();
            return Ok(data);
        }


        [HttpPatch("/admin/award/update/{guessId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> updateStatusAward(int guessId)
        {
            bool result = await _awardService.updateStatusAward(guessId);
            if (result) 
                return Ok();
            return BadRequest();
        }
    }
}
