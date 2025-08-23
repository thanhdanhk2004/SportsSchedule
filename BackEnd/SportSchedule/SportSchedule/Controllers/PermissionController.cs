using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("/permissions")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> getPermissions()
        {
            var data = await _permissionService.getPermissions();
            if (data == null) 
                return NotFound();
            return Ok(data);
        }

        [HttpPost("/permission/add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> addPermission(string permissionName)
        {
            bool result = await _permissionService.addPermission(permissionName);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("/permission/delete/{permisisonId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> deletePermisison(int permisisonId)
        {
            bool result = await _permissionService.deletePermission(permisisonId);
            if(!result)
                return BadRequest();
            return Ok();
        }

        [HttpPatch("/permission/update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> updatePermission(PermissionModel permission)
        {
            bool result = await _permissionService.updatePermission(permission);
            if(result)
                return Ok();
            return BadRequest();
        }
    }
}
