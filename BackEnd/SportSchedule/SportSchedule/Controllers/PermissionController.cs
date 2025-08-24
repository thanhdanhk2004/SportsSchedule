using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportSchedule.DataTranserferObject.Permission;
using SportSchedule.Model;
using SportSchedule.Services.Permission;

namespace SportSchedule.Controllers
{
    [ApiController]
    public class PermissionController : Controller
    {
        private readonly IPermissionService _permissionService;
        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet("/admin/permissions")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> getPermissions()
        {
            var data = await _permissionService.getPermissions();
            if (data == null) 
                return NotFound();
            return Ok(data);
        }

        [HttpPost("/admin/permission/add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> addPermission(PermissionDTO permissionDTO)
        {
            bool result = await _permissionService.addPermission(permissionDTO);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("/admin/permission/delete/{permisisonId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> deletePermisison(int permisisonId)
        {
            bool result = await _permissionService.deletePermission(permisisonId);
            if(!result)
                return BadRequest();
            return Ok();
        }

        [HttpPut("/admin/permission/update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> updatePermission(PermissionDTO permission)
        {
            bool result = await _permissionService.updatePermission(permission);
            if(result)
                return Ok();
            return BadRequest();
        }
    }
}
