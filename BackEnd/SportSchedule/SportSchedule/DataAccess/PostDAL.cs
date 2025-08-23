using Microsoft.EntityFrameworkCore;
using SportSchedule.Context;
using SportSchedule.DataTranserferObject.Article;
using SportSchedule.Model;

namespace SportSchedule.DataAccess
{
    public class PostDAL
    {
        private readonly ContextDB _context;
        private readonly UserDAL _userDAL;

        public PostDAL(ContextDB context, UserDAL userDAL)
        {
            _context = context;
            _userDAL = userDAL;
        }

        //Them bai viet
        public void addArticle(ArticleDTO article, string username)
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
                    UserId = _userDAL.getUserId(username),
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
        
        //Chinh sua (member)  bai viet
        public void updateArticle(ArticleDTO article, int articleId)
        {
            try
            {
                if (article == null) return;
                var model = _context.Posts.FirstOrDefault(p => p.PostId == articleId);
                if (model == null)
                    return;
                model.Title = article.Title;
                model.Description = article.Description;
                model.Image = article.Image;
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

        //Xem bai viet theo id bai viet
        public ArticleDTOFE getArticleByArticleId(int article_id)
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
                        AuthorName = p.User.LastName + p.User.FirstName,
                        CreatedDate = p.Created.Value.ToString("dd/MM/yyyy hh:mm"),
                    }).FirstOrDefault();
                return article;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //Xem bai viet thoe user id
        public List<ArticleDTOFE> GetArticlesByUserId(string username)
        {
            try
            {
                if (username == null)
                    return null;
                var data = _context.Posts.Where(p => p.UserId == _userDAL.getUserId(username))
                    .Select(p => new ArticleDTOFE
                    {
                        ArticleId = p.PostId,
                        Title = p.Title,
                        Description = p.Description,
                        Image = p.Image,
                        CreatedDate = p.Created.Value.AddHours(7).ToString("dd/MM/yyyy hh:mm:ss"), 
                        Status = p.Status,
                    }).ToList();
                Console.WriteLine(data[0].Title);
                return data;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //Xem bai viet theo trang
        public List<ArticlePageDTOFE> getArticleByPage(int page)
        {
            var articles = _context.Posts.Include(p => p.User)
                        .Where(p => p.Status == "Đã duyệt")
                        .OrderByDescending(p => p.Created)
                        .Select(p => new ArticlePageDTOFE
                        {
                            ArticleId = p.PostId,
                            Title = p.Title,
                            Image = p.Image,
                            TotalPage = (int)(Math.Ceiling((decimal)_context.Posts.Count(p => p.Status == "Đã duyệt") / 3))
                        })
                        .ToList();
            articles[0].TotalPage = (int)(Math.Ceiling((decimal)articles.Count / 3));
            return articles.Skip(page * 3).Take(3).ToList();
        }

        //Admin duyet bai viet
        public bool updateStatusArticle(int article_id)
        {
            try
            {
                if(article_id  == null) 
                    return false;
                var article = _context.Posts.FirstOrDefault(p => p.PostId == article_id);
                if(article == null)
                    return false;
                article.Status = "Đã duyệt";
                _context.Posts.Update(article);
                _context.SaveChanges();
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
