using Newsletter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Userletter.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<bool> ExistUser(int id);
        Task<bool> DeleteUser(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
    }
}
