using SportSchedule.Services.Appointment;

namespace SportSchedule.Context.Seed
{
    public class DataSeedMail
    {
        public static async Task SeedDataMail(ContextDB _context, IAppointmentService _appointmentService)
        {
            var appointments = await _appointmentService.getAppointments();
            if(appointments != null)
            {
                foreach(var appointment in appointments)
                {
                    await _appointmentService.SendEmailAsync(appointment?.Email!, appointment?.MatchId ?? 0);
                    await _appointmentService.UpdateAppointment(appointment?.AppointmentId ?? 0);
                }
            }
        }
        
    }
}
