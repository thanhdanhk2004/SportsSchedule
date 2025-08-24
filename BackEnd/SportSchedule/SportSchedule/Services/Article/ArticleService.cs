using SportSchedule.DataAccess;
using SportSchedule.DataTranserferObject.Appointment;
using SportSchedule.DataTranserferObject.Article;
using System.Net;
using System.Net.Mail;
using System.Text.Json;

namespace SportSchedule.Services.Article
{
    public class ArticleService : IArticleService
    {
        private readonly PostDAL _postDAL;
        private SmtpClient client;
        private string key;

        //Chuc nang cua member
        public ArticleService(PostDAL postDAL)
        {
            _postDAL = postDAL;
            key = File.ReadAllText("key.json");
            var data = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(key);
            client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(data["MyApiSettings"]["MailFrom"], data["MyApiSettings"]["ApiKeyEmail"])
            };
        }

        public async Task deleteArticle(int? article_id)
        {
            if (article_id == null)
                return;
            _postDAL.deleteArticle(article_id);
        }

        public async Task<List<ArticleDTOFE>> getArticlesByUserId(string username)
        {
            var data = _postDAL.GetArticlesByUserId(username);
            return data;
        }

        public async Task<ArticleDTOFE> getArticleByArticleId(int? article_id)
        {
            if (!article_id.HasValue)
                return null;
            return _postDAL.getArticleByArticleId(article_id.Value);
        }

        public async Task postArticle(ArticleDTO article, string username)
        {
            if(article == null)
                return;
            _postDAL.addArticle(article, username);
        }

        public async Task updateArticle(ArticleDTO article, int articleId)
        {
            if (article == null)
                return;
            _postDAL.updateArticle(article, articleId);
        }

        public async Task<List<ArticlePageDTOFE>> getArticlesByPage(int page)
        {
            if (page == null)
                return null;
            return _postDAL.getArticleByPage(page);
        }

        //Chuc nang cua admin
        //Chuc nang cap nhật trang thai bai viet
        public async Task<bool> updateStatusArticle(int article_id)
        {
            try
            {
                if (article_id == null)
                    return false;
                var result = _postDAL.updateStatusArticle(article_id);
                if(result == true)
                {
                    Console.WriteLine("Hello");
                    await this.sendMail(article_id);
                    return true;
                }

                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //Gui mail sau khi duyet bai
        public async Task sendMail(int articleId)
        {
            try
            {
                string email = _postDAL.getEmail(articleId);
                var data = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(key);
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(data["MyApiSettings"]["MailFrom"]);
                mail.To.Add(email);
                string emailBody = "Chúc mừng bài viết số " + articleId.ToString() + " của bạn đã được duyệt vui lòng kiểm tra trên hệ thống";
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
        //Lay danh sach bai viet
        public async Task<List<ArticleDTOFEAdmin>> getArticleByPageAdmin(int page)
        {
            try
            {
                if (page == null)
                    return null!;
                return _postDAL.getArticleByPageAdmin(page);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }
    }
}
