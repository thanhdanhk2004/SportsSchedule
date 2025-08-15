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

        public bool updateUser(string username, string password, string email)
        {
            throw new NotImplementedException();
        }
    }
}
