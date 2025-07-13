using Microsoft.EntityFrameworkCore;
using SportSchedule.Context;
using SportSchedule.DataTranserferObject;
using SportSchedule.Model;


namespace SportSchedule.Services.Users
{
    public class UserService : IUserSevice
    {
        private readonly ContextDB _context;
        public UserService(ContextDB context)
        {
            _context = context;
        }

        public bool check_user(string username)
        {
            var user = _context.Accounts.Where(u => u.UserName == username).FirstOrDefault();
            if (user == null)
                return true;
            return false;
        }

        public bool check_email(string email)
        {
            var user = _context.Users.Where(u => u.Email == email).FirstOrDefault();
            if (user == null) return true;
            return false;
        }

        public string addUser(UserDataTransferObject user_data)
        {
            if (user_data.LastName == "" || user_data.FirstName == "" || user_data.Email == "" || user_data.UserName == "" || user_data.Password == "")
                return "Các thông tin không được rỗng";
            else if (!check_user(user_data.UserName))
                return "Tên đăng nhập đã tồn tại";
            else if (!check_email(user_data.Email))
                return "Email đã tồn tại";

            int user_count = _context.Users.Count();
            UserModel user = new UserModel
            {
                UserId = user_count + 1 < 99999999 ? "U" + (user_count + 1).ToString("D10") : "U" + (user_count + 1).ToString("D11"),
                LastName = user_data.LastName,
                FirstName = user_data.FirstName,
                Email = user_data.Email
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            int number_account = _context.Accounts.Count();
            AccountModel account = new AccountModel
            {
                AccountId = number_account + 1 < 99999999 ? "A" + (user_count + 1).ToString("D10") : "A" + (user_count + 1).ToString("D11"),
                UserName = user_data.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(user_data.Password),
                UserId = user.UserId,
            };
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return "";
        }

        public bool addUser(string username, string password, string email)
        {
            throw new NotImplementedException();
        }

        public UserDataTransferObject getUser(string username, string password)
        {
            var u = _context.Accounts.Include(a => a.User).Where(a => a.UserName == username && a.Password == password).FirstOrDefault();

            if (u == null)
                return null;
            UserDataTransferObject user = new UserDataTransferObject
            {
               
            };
            return user;
        }

        public bool updateUser(string username, string password, string email)
        {
            throw new NotImplementedException();
        }
    }
}
