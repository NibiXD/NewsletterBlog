using AutoMapper;
using Newsletter.Data;
using Newsletter.Dtos;
using Newsletter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Userletter.Services.Interfaces;

namespace Newsletter.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IMapper _mapper;

        public SubscriberService(ISubscriberRepository subscriberRepository, IMapper mapper)
        {
            _subscriberRepository = subscriberRepository;
            _mapper = mapper;
        }

        public async Task<Subscriber> AddUser(SubscriberDto user)
        {
            var result = _mapper.Map<Subscriber>(user);
            return await _subscriberRepository.AddAsync(result);
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

        public async Task<Subscriber> UpdateUser(SubscriberDto user)
        {
            var result = _mapper.Map<Subscriber>(user);
            return await _subscriberRepository.UpdateAsync(result);
        }
    }
}
