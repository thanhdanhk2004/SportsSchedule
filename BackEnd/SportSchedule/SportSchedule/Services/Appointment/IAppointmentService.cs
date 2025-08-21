using SportSchedule.DataTranserferObject.Appointment;

namespace SportSchedule.Services.Appointment
{
    public interface IAppointmentService
    {
        Task addAppointment(int match_id, string username);
        Task<List<int?>> getMatchAppointmented(string username);
        Task SendEmailAsync(string email, int matchId);
        Task<List<AppointmentDTO?>> getAppointments();
        Task UpdateAppointment(int appointmentId);
    }
}
