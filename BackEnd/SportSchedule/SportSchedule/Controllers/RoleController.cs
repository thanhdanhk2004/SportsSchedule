using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportSchedule.Services.Role;

namespace SportSchedule.Controllers
{
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("/admin/roles")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> getRoles()
        {
            var data = await _roleService.getRoles();
            if(data == null) 
                return NotFound();
            return Ok(data);
        }
    }
}
