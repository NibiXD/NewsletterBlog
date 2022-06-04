using Newsletter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Userletter.Services.Interfaces
{
    public interface ISubscriberService
    {
        Task<Subscriber> AddUser(Subscriber user);
        Task<Subscriber> UpdateUser(Subscriber user);
        Task<bool> ExistUser(int id);
        Task<bool> DeleteUser(int id);
        Task<IEnumerable<Subscriber>> GetAllUsers();
        Task<Subscriber> GetUserById(int id);
    }
}
