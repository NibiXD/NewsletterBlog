using Newsletter.Dtos;
using Newsletter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Userletter.Services.Interfaces
{
    public interface ISubscriberService
    {
        Task<Subscriber> AddUser(SubscriberDto user);
        Task<Subscriber> UpdateUser(SubscriberDto user);
        Task<bool> ExistUser(int id);
        Task<bool> DeleteUser(int id);
        Task<IEnumerable<Subscriber>> GetAllUsers();
        Task<Subscriber> GetUserById(int id);
    }
}
