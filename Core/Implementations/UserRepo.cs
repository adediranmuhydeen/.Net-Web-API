using Core.Services;
using Entity.DTO;
using Entity.Model;

namespace Core.Implementations
{
    internal class UserRepo : IUser
    {
        public Task<bool> AddUser(UserRegistrationDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeUserEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeUserPassword(UserChangePasswordDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
