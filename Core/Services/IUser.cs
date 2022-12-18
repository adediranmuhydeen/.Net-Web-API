using Entity.DTO;
using Entity.Model;

namespace Core.Services
{
    public interface IUser
    {
        Task<bool> AddUser(UserRegistrationDto userDto);
        Task<bool> ChangeUserPassword(UserChangePasswordDto userDto);
        Task<bool> DeleteUser(string email);
        Task<bool> ChangeUserEmail(string email);
        Task<List<User>> GetUsers();
    }
}
