using SportSchedule.DataTranserferObject.User;

namespace SportSchedule.Services.Users
{
    public interface IUserSevice
    {
        //Chuc nang cu user
        UserDTOFE? getUser(UserDTO user);
        string addUser(UserDTO user);

        //Chuc nang cua admin
        Task<List<UserDTOFEAdmin>> getUsers();
        Task<bool> deleteUser(int userId);
        Task<UserDTOFEAdmin> getUser(int userId);
        Task<bool> updateUser(UserDTOUpdate user);
    }
}
