using Newsletter.Data;
using Newsletter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Userletter.Services.Interfaces;

namespace Newsletter.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddUser(User user)
        {
            return await _userRepository.AddAsync(user);
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistUser(int id)
        {
            return await _userRepository.ExistAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> UpdateUser(User user)
        {
            return await _userRepository.UpdateAsync(user);
        }
    }
}
