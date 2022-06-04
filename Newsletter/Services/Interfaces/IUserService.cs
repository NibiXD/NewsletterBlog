using Microsoft.AspNetCore.Identity;
using Newsletter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Newsletter.Services
{
    public interface IUserService
    {
        Task<IdentityUser> GetUserById(string id);
        Task<IdentityUser> GetUserByUserName(string userName);
        Task<IEnumerable<IdentityUser>> GetAllUsers();
        Task<IdentityUser> CreateUser(CreateUser createUser);
        Task<IdentityUser> UpdateUser(IdentityUser user);
        Task<bool> ExistsUser(string id);
        Task<bool> DeleteUser(string id);
        Task<string> GenerateJwtToken(CreateUser user);
    }
}
