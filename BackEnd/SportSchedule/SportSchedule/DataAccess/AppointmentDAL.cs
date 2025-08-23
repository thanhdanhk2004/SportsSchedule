using Microsoft.EntityFrameworkCore;
using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Appointment;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class AppointmentDAL
    {
        private readonly ContextDB _context;
        private readonly UserDAL _userDAL;
        public AppointmentDAL(ContextDB context, UserDAL userDAL)
        {
            _context = context;
            _userDAL = userDAL;
        }

        //Lay tran dau theo id tran dau (De gui mail)
        public ScheduleDTOFE getSchedule(int match_id)
        {
            try
            {
                if (match_id == null)
                    return null;
                var data = (from m in _context.Matches
                            join th in _context.Teams on m.TeamIdHome equals th.TeamId
                            join ta in _context.Teams on m.TeamIdAway equals ta.TeamId
                            where m.MatchId == match_id
                            select new ScheduleDTOFE
                            {
                                TeamNameHome = th.Name,
                                TeamNameAway = ta.Name,
                                MatchTime = m.Time.ToString(),
                                LogoNameHome = th.Logo,
                                LogoNameAway = ta.Logo,
                            }).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        //Them appointment
        public void addAppoint(int matchId, string username)
        {
            try
            {
                if (matchId == 0 || username == null)
                    return;
                AppointmentModel model = new AppointmentModel
                {
                    MatchId = matchId,
                    UserId = _userDAL.getUserId(username),
                    DateSend = DateTime.UtcNow,
                    Status = false
                };
                _context.Appointments.Add(model);   
                _context.SaveChanges();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
        }
        //Lay cac tran dau ma nguoi dung da hen lich
        public List<int?> getMatchAppointmented(string username)
        {
            try
            {
                if (username == null)
                    return null!;
                var data = _context.Appointments
                            .Where(a => a.UserId == _userDAL.getUserId(username))
                            .Select(a => a.MatchId)
                            .ToList();
                return data;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null!;
            }
        }

        //Lay cac tran dau phu hop de gui mail
        public List<AppointmentDTO?> getAppointment()
        {
            try
            {
                var appointments = (from a in _context.Appointments
                                   join m in _context.Matches on a.MatchId equals m.MatchId
                                   join u in _context.Users on a.UserId equals u.UserId
                                   where a.Status == false &&
                                         (m.Time.Value <= DateTime.UtcNow.AddHours(31)
                                         && m.Time.Value >= DateTime.UtcNow.AddHours(19))
                                    select new AppointmentDTO{
                                       AppointmentId = a.AppointmentId,
                                       MatchId = m.MatchId,
                                       Email = u.Email
                                   }).ToList();
                return appointments;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null!;
            }
        }

        //Update trang thai sau khi gui mail
        public void updateAppointment(int appointmentId)
        {
            try
            {
                if(appointmentId == 0)
                    return;
                var appointment = _context.Appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
                if(appointment == null)
                    return;
                appointment.Status = true;
                appointment.DateSend = DateTime.UtcNow;
                _context.Appointments.Update(appointment);
                _context.SaveChanges();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
        }
    }
}
