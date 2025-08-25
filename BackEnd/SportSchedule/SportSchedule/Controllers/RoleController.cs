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

        [HttpPost("/admin/role/add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> addRole(string roleName)
        {
            bool resutl = await _roleService.addRole(roleName);
            if (resutl)
                return Ok();
            return BadRequest();
        }

        [HttpDelete("/admin/role/delete/{roleId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> deleteRole(int roleId)
        {
            var result = await _roleService.removeRole(roleId);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpPatch("/admin/role/update/{roleId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> updateRole(int roleId, string roleName)
        {
            var result = await _roleService.updateRole(roleId, roleName);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}
