using Microsoft.EntityFrameworkCore;
using SportSchedule.Context;
using SportSchedule.DataAccess;
using SportSchedule.DataTranserferObject.User;
using SportSchedule.Model;
using System.Security.Principal;

namespace SportSchedule.Services.Users
{
    public class UserService : IUserSevice
    {
        private readonly ContextDB _context;
        private readonly IConfiguration _configuration;
        private readonly UserDAL _userDAL;
        public UserService(ContextDB context,IConfiguration configuration, UserDAL userDAL)
        {
            _context = context;
            _configuration = configuration;
            _userDAL = userDAL;
        }

        //Them user khi dang ky tai khoan
        public string addUser(UserDTO user_data)
        {
            if (user_data == null)
                return "Loi";   
            return _userDAL.addUser(user_data);
        }

        

        //Them user khi dang nhap tai khoan
        public UserDTOFE? getUser(UserDTO user_data)
        {
            if(user_data == null)
                return null;
            return _userDAL.getInforUser(user_data);
        }


        //Chuc nang cua admin
        public async Task<UserDTOFEAdmin> getUser(int userId)
        {
            try
            {
                if (userId == 0)
                    return null;
                return _userDAL.getUser(userId);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<UserDTOFEAdmin>> getUsers()
        {
            try
            {
                return _userDAL.getUsers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<bool> updateUser(UserDTOUpdate user)
        {
            try
            {
                if (user == null)
                    return false;
                return _userDAL.updateUser(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> deleteUser(int userId)
        {
            try
            {
                if (userId == null)
                    return false;
                return _userDAL.deleteUser(userId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
