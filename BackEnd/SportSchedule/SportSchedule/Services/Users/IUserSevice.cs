using SportSchedule.DataTranserferObject.User;

namespace SportSchedule.Services.Users
{
    public interface IUserSevice
    {
        UserDTOFE? getUser(UserDTO user);
        string addUser(UserDTO user);
        Boolean updateUser(string username, string password, string email);
    }
}
