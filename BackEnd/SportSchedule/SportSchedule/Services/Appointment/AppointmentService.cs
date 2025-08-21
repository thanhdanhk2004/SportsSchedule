using System.Net.Mail;
using System.Net;
using System.Net.Http;
using SportSchedule.DataAccess;
using System.Text.Json;
using SportSchedule.DataTranserferObject.Appointment;

namespace SportSchedule.Services.Appointment
{
    public class AppointmentService:IAppointmentService
    {
        private readonly AppointmentDAL _appointmentDAL;
        private SmtpClient client;
        private string key;
        public AppointmentService(AppointmentDAL appointmentDAL)
        {
            _appointmentDAL = appointmentDAL;
            key = File.ReadAllText("key.json");
            var data = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(key);
            client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(data["MyApiSettings"]["MailFrom"], data["MyApiSettings"]["ApiKeyEmail"])
            };
        }

        //Them lich
        public async Task addAppointment(int match_id, string username)
        {
            _appointmentDAL.addAppoint(match_id, username);
            return;
        }

        //Gui mail
        public async Task SendEmailAsync(string email, int matchId)
        {
            try
            {
                ScheduleDTOFE schedule = _appointmentDAL.getSchedule(matchId);
                var data = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(key);
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(data["MyApiSettings"]["MailFrom"]);
                mail.To.Add(email);
                string emailBody = File.ReadAllText(@"Services\Appointment\ContentMail.html");
                if(emailBody != null)
                {
                    emailBody = emailBody.Replace("[TeamHome]", schedule.TeamNameHome)
                                         .Replace("[TeamAway]", schedule.TeamNameAway)
                                         .Replace("[LogoHome]", schedule.LogoNameHome)
                                         .Replace("[LogoAway]", schedule.LogoNameAway)
                                         .Replace("[Time]", schedule.MatchTime);
                }
                mail.Body = emailBody;
                mail.IsBodyHtml = true;
                client.Send(mail);
                return;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //Lay Id va matchId de gui mail
        public async Task<List<AppointmentDTO?>> getAppointments()
        {
            return _appointmentDAL.getAppointment();
        }

        //Lay cac tran dau da hen lich gui cho FE
        public async Task<List<int?>> getMatchAppointmented(string username)
        {
            return _appointmentDAL.getMatchAppointmented(username);
        }

        public async Task UpdateAppointment(int appointmentId)
        {
            _appointmentDAL.updateAppointment(appointmentId);
            return;
        }
    }
}
