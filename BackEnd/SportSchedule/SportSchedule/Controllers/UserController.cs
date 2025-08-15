using Microsoft.AspNetCore.Mvc;
using SportSchedule.DataTranserferObject.User;
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
        public async Task<IActionResult> Register(UserDTO user)
        {
            string message = _userSevice.addUser(user);
            if(message == "")
                return Ok(new { message });
            return BadRequest(new { message });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDTO user_data)
        {
            var u = _userSevice.getUser(user_data);
            if (u == null)
                return BadRequest(new { message = "Tên đăng nhập hoặc mật khẩu không chính xác" });
            return Ok(new
            {
                message = "Đăng nhập thành công",
                user = u
            });
        }
    }
}
