using SportSchedule.DataAccess;
using SportSchedule.DataTranserferObject.Award;
using System.Net;
using System.Net.Mail;
using System.Text.Json;

namespace SportSchedule.Services.Award
{
    public class AwardService : IAwardService
    {
        private readonly AwardDAL _awardDAL;
        private SmtpClient client;
        private string key;
        public AwardService(AwardDAL awardDAL)
        {
            _awardDAL = awardDAL;
            key = File.ReadAllText("key.json");
            var data = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(key);
            client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(data["MyApiSettings"]["MailFrom"], data["MyApiSettings"]["ApiKeyEmail"])
            };
        }
        public async Task<bool> addAward(int guessId)
        {
            try
            {
                if(guessId == null)
                    return false;
                bool resutl = _awardDAL.addAward(guessId);
                if(resutl)
                {
                    await this.sendMail(guessId);
                    return true;
                }
                return false;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<List<AwardDTOFEAdmin>> getGuessExactly(int matchId)
        {
            try
            {
                if (matchId == null)
                    return null!;
                return _awardDAL.getGuessExactly(matchId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null!;
            }
        }

        public async Task<List<AwardStatusDTOFEAdmin>> getListAward()
        {
            try
            {
                return _awardDAL.getListAward();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null!;
            }
        }

        public async Task sendMail( int guessId)
        {
            try
            {
                string email = _awardDAL.getEmailUserGuess(guessId);
                var data = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(key);
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(data["MyApiSettings"]["MailFrom"]);
                mail.To.Add(email);
                string emailBody = "Chúc mừng bạn đã trúng thưởng khi chơi minigame vui lòng reply email này cũng cấp stk ngân hàng";
                mail.Body = emailBody;
                mail.IsBodyHtml = true;
                client.Send(mail);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task<bool> updateStatusAward(int guessId)
        {
            try
            {
                if (guessId == null)
                    return false;
                return _awardDAL.updateAward(guessId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

    }
}
