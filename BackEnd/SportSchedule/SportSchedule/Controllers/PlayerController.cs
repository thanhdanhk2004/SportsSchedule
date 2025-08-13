using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SportSchedule.Services.Member;

namespace SportSchedule.Controllers
{
    [ApiController]
    [Route("/player")]
    public class PlayerController:Controller
    {
        private readonly IMemberService _memberService;
        public PlayerController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpGet("{player_id}")]
        public async Task<IActionResult> getPlayer(int player_id)
        {
            var data = await _memberService.getPlayerInfo(player_id);
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
