using Microsoft.EntityFrameworkCore;
using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Article;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class PostDAL
    {
        private readonly ContextDB _context;
        public PostDAL(ContextDB context)
        {
            _context = context;
        }

        //Them bai viet
        public void addArticle(ArticleDTO article)
        {
            try
            {
                if(article == null) 
                    return;
                PostModel model = new PostModel
                {
                    Title = article.Title,
                    Description = article.Description,
                    Image = article.Image,
                    Created = DateTime.UtcNow,
                    UserId = 3,
                    Status = "Chờ duyệt"
                };
                _context.Posts.Add(model);
                _context.SaveChanges();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        
        //Chinh sua (member) hoac cap nhat trang thai (admin) bai viet
        public void updateArticle(ArticleDTO article)
        {
            try
            {
                if (article == null) return;
                var model = _context.Posts.FirstOrDefault(p => p.PostId == article.ArticleId);
                if (model == null)
                    return;
                model.Title = article.Title;
                model.Description = article.Description;
                model.Image = article.Image;
                model.Status = article.Status;
                _context.Posts.Update(model);
                _context.SaveChanges();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        //Xoa bai viet
        public void deleteArticle(int? article_id)
        {
            try
            {
                if(article_id == null) return;
                var article = _context.Posts.FirstOrDefault(p => p.PostId == article_id);
                if (article == null) return;
                _context.Posts.Remove(article);
                _context.SaveChanges();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        //Xem bai viet
        public ArticleDTOFE getArticle(int article_id)
        {
            try
            {
                if (article_id == null)
                    return null;
                var article = _context.Posts.Include(u => u.User)
                    .Where(p => p.PostId == article_id)
                    .Select(p => new ArticleDTOFE
                    {
                        ArticleId = article_id,
                        Title = p.Title,
                        Description = p.Description,
                        Image = p.Image,
                        AuthorName = p.User.LastName + p.User.FirstName
                    }).FirstOrDefault();
                return article;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
