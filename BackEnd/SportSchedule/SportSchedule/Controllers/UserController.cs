using Microsoft.AspNetCore.Mvc;
using SportSchedule.DataTranserferObject;
using SportSchedule.Services.Users;

namespace SportSchedule.Controllers
{
    [ApiController]
    [Route("user/")]
    public class UserController : Controller
    {
        private readonly IUserSevice _userSevice;
        public UserController(IUserSevice userSevice)
        {
            _userSevice = userSevice;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDataTransferObject user)
        {
            string message = _userSevice.addUser(user);
            if(message == "")
                return Ok(new { message });
            return BadRequest(new { message });
        }
    }
}
