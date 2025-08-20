using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportSchedule.DataTranserferObject.Guess;
using SportSchedule.Services.Guess;

namespace SportSchedule.Controllers
{
    [ApiController]
    [Route("/guess")]
    public class GuessControler : Controller
    {
        private readonly IGuessService _guessService;
        public GuessControler(IGuessService guessService)
        {
            _guessService = guessService;
        }

        [HttpGet("{time}")]
        public async Task<IActionResult> getMatchsGuess(string time)
        {
            var data = await _guessService.matchGuess(time);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPost("add/{matchId}")]
        [Authorize(Roles = "Member", Policy = "permission.Minigame")]
        public async Task<IActionResult> addGuess(GuessDTO guess, int matchId)
        {
            string username = User.Identity.Name;
            bool result = await _guessService.addGuess(guess, username, matchId);
            if (result)
               return Ok();
            return BadRequest();
        }
    }
}
