using Microsoft.EntityFrameworkCore;
using SportSchedule.Context;
using SportSchedule.DataTranserferObject.User;
using SportSchedule.Model;
using System.Security.Principal;


namespace SportSchedule.Services.Users
{
    public class UserService : IUserSevice
    {
        private readonly ContextDB _context;
        private readonly IConfiguration _configuration;
        public UserService(ContextDB context,IConfiguration configuration )
        {
            _context = context;
            _configuration = configuration;
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
                LastName = user_data.LastName,
                FirstName = user_data.FirstName,
                Email = user_data.Email,
                RoleId = 2
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            int number_account = _context.Accounts.Count();
            AccountModel account = new AccountModel
            {
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

        public UserDataLogin? getUser(UserDataTransferObject user_data)
        {
            var u = _context.Accounts.Include(a => a.User)
                .Where(a => a.UserName == user_data.UserName)
                .FirstOrDefault();

            if (u == null)
                return null;
            else if (!BCrypt.Net.BCrypt.Verify(user_data.Password, u.Password))
                return null;

            GenerateJwtToken generateJwtToken = new GenerateJwtToken(_context);
      
            UserDataLogin user = new UserDataLogin
            {
                Email = u.User?.Email,
                FirstName = u.User?.FirstName,
                LastName = u.User?.LastName,
                Role = u.User?.RoleId,
                Token = generateJwtToken.generate(u, _configuration)
            };
            return user;
        }

        public bool updateUser(string username, string password, string email)
        {
            throw new NotImplementedException();
        }
    }
}
