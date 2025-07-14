using SportSchedule.DataTranserferObject.User;

namespace SportSchedule.Services.Users
{
    public interface IUserSevice
    {
        UserDataLogin? getUser(UserDataTransferObject user);
        string addUser(UserDataTransferObject user);
        Boolean updateUser(string username, string password, string email);
    }
}
