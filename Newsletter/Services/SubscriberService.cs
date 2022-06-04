using Newsletter.Data;
using Newsletter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Userletter.Services.Interfaces;

namespace Newsletter.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly ISubscriberRepository _subscriberRepository;

        public SubscriberService(ISubscriberRepository subscriberRepository)
        {
            _subscriberRepository = subscriberRepository;
        }

        public async Task<Subscriber> AddUser(Subscriber user)
        {
            return await _subscriberRepository.AddAsync(user);
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _subscriberRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistUser(int id)
        {
            return await _subscriberRepository.ExistAsync(id);
        }

        public async Task<IEnumerable<Subscriber>> GetAllUsers()
        {
            return await _subscriberRepository.GetAllAsync();
        }

        public async Task<Subscriber> GetUserById(int id)
        {
            return await _subscriberRepository.GetByIdAsync(id);
        }

        public async Task<Subscriber> UpdateUser(Subscriber user)
        {
            return await _subscriberRepository.UpdateAsync(user);
        }
    }
}
