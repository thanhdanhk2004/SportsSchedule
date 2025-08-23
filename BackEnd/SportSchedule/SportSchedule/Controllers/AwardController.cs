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

        [HttpPost("/award/add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> addAward(int guessId)
        {
            bool result = await _awardService.addAward(guessId);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpGet("/guess/{matchId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> getGuessExactly(int matchId)
        {
            var data = await _awardService.getGuessExactly(matchId);
            if(data == null)    
                return NotFound();
            return Ok(data);
        }

        [HttpPatch("/award/update/{awardId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> updateStatusAward(int awardId)
        {
            bool result = await _awardService.updateStatusAward(awardId);
            if (result) 
                return Ok();
            return BadRequest();
        }
    }
}
