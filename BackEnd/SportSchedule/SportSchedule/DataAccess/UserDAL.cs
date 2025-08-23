using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SportSchedule.Context;
using SportSchedule.DataTranserferObject.User;
using SportSchedule.Model;
using SportSchedule.Services.Users;

namespace SportSchedule.DataAccess
{
    public class UserDAL
    {
        private readonly ContextDB _context;
        private readonly IConfiguration _configuration;

        public UserDAL(ContextDB context, IConfiguration configuration)
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

        //Them user khi dang ky tai khoan
        public string addUser(UserDTO user_data)
        {
            try
            {
                if (user_data.LastName == "" || user_data.FirstName == "" || user_data.Email == "" || user_data.UserName == "" || user_data.Password == "")
                    return "Các thông tin không được rỗng";
                else if (!check_user(user_data.UserName))
                    return "Tên đăng nhập đã tồn tại";
                else if (!check_email(user_data.Email))
                    return "Email đã tồn tại";
                UserModel user = new UserModel
                {
                    LastName = user_data.LastName,
                    FirstName = user_data.FirstName,
                    Email = user_data.Email,
                    RoleId = 1
                };
                _context.Users.Add(user);
                _context.SaveChanges();
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return ex.ToString();
            }
        }

        //Lay user khi dang nhap tai khoan
        public UserDTOFE getInforUser(UserDTO user_data)
        {
            try
            {
                var u = _context.Accounts.Include(a => a.User).Include(u => u.User.Role)
                .Where(a => a.UserName == user_data.UserName)
                .FirstOrDefault();

                if (u == null)
                    return null;
                else if (!BCrypt.Net.BCrypt.Verify(user_data.Password, u.Password))
                    return null;

                GenerateJwtToken generateJwtToken = new GenerateJwtToken(_context);

                UserDTOFE user = new UserDTOFE
                {
                    Email = u.User?.Email,
                    FirstName = u.User?.FirstName,
                    LastName = u.User?.LastName,
                    Role = u.User?.RoleId,
                    Token = generateJwtToken.generate(u, _configuration)
                };
                return user;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public int getUserId(string username)
        {
            try
            {
                if (username == null)
                    return -1;
                return (int)_context.Accounts.Where(a => a.UserName == username)
                    .Select(a => a.UserId).FirstOrDefault()!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }

        
        //Chuc nang cua Admin
        //Lay danh sach cac user
        public List<UserDTOFEAdmin> getUsers()
        {
            try
            {
                var users = _context.Users.Include(u => u.Account).Include(u => u.Role)
                    .Select(u => new UserDTOFEAdmin
                    {
                        UserId = u.UserId,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        UserName = u.Account!.UserName,
                        Password = u.Account!.Password,
                        Email = u.Email,
                        RoleName = u.Role!.Name
                    }).ToList();
                return users;
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        //Xoa user
        public bool deleteUser(int userId)
        {
            try
            {
                if(userId == null)
                    return false;
                var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
                if(user == null) 
                    return false;
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        //Lay thong tin user de chinh sua
        public UserDTOFEAdmin getUser(int userId)
        {
            try
            {
                if (userId == null)
                    return null;
                var user = _context.Users.Include(u => u.Account)
                    .Include(u => u.Role)
                    .Where(u => u.UserId == userId)
                    .Select(u => new UserDTOFEAdmin
                    {
                        UserId = u.UserId,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        UserName = u.Account!.UserName,
                        Password = u.Account!.Password,
                        Email = u.Email,
                        RoleName = u.Role!.Name
                    }).FirstOrDefault();
                if (user == null)
                    return null!;
                return user;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        //Edit user
        public bool updateUser(UserDTOUpdate user)
        {
            try
            {
                if(user == null)
                    return false;
                //Tim user
                var userExisted = _context.Users.FirstOrDefault(u => u.UserId == user.UserId);
                if(userExisted == null)
                    return false;

                //Tim accout
                var accoutExisted = _context.Accounts.FirstOrDefault(a => a.UserId == user.UserId);
                if(accoutExisted == null)
                    return false;

                userExisted.LastName = user.LastName;
                userExisted.FirstName = user.FirstName;
                userExisted.Email = user.Email;
                _context.Users.Update(userExisted);
                accoutExisted.UserName = user.UserName;
                accoutExisted.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                _context.Accounts.Update(accoutExisted);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
