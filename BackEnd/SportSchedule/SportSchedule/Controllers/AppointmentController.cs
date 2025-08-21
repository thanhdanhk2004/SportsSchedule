using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportSchedule.Services.Appointment;

namespace SportSchedule.Controllers
{
    [ApiController]
    [Route("/appointment")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("{matchId}")]
        [Authorize(Roles = "Member", Policy = "permission.Appointment")]
        public async Task<IActionResult> addAppointment(int matchId)
        {
            string username = User.Identity?.Name!;
            await _appointmentService.addAppointment(matchId, username);
            return Ok();
        }

        [HttpGet("/appointmented")]
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> getMatchAppointmented()
        {
            string username = User.Identity?.Name!;
            var data = await _appointmentService.getMatchAppointmented(username);
            return Ok(data);
        }
    }
}
