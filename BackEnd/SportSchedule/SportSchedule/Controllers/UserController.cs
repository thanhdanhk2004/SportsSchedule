using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("/users")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> getUsers()
        {
            var data = await _userSevice.getUsers();
            if(data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> getUser(int userId)
        {
            var data = await _userSevice.getUser(userId);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpDelete("delete/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> deleteUser(int userId)
        {
            bool resutle = await _userSevice.deleteUser(userId);
            if(resutle)
                return Ok();
            return BadRequest();
        }

        [HttpPut("update")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> updateUser(UserDTOUpdate user)
        {
            bool resutl = await _userSevice.updateUser(user);
            if(resutl)
                return Ok();
            return BadRequest();
        }
    }
}
