using SportSchedule.DataTranserferObject;

namespace SportSchedule.Services.Users
{
    public interface IUserSevice
    {
        UserDataTransferObject? getUser(string username, string password);
        string addUser(UserDataTransferObject user);
        Boolean updateUser(string username, string password, string email);
    }
}
