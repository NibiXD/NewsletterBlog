using Newsletter.Models;
using System.Collections.Generic;
using Newsletter.Data;
using System.Threading.Tasks;
using Newsletter.Dtos;
using AutoMapper;

namespace Newsletter.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly ISubscriberRepository _userRepository;
        private readonly EmailSenderService _emailSenderService;
        private readonly IMapper _mapper;

        public NewsService(INewsRepository newsRepository, EmailSenderService emailSenderService, ISubscriberRepository userRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _emailSenderService = emailSenderService;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<News> AddNews(NewsDto news)
        {
            var result = _mapper.Map<News>(news);
            await _newsRepository.AddAsync(result);
            IEnumerable<Subscriber> user = await _userRepository.GetAllAsync();

            foreach (Subscriber userItem in user)
            {
                _emailSenderService.SendMail(userItem.Email, result);
            }

            return result;
        }

        public async Task<bool> DeleteNews(int id)
        {
            return await _newsRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistNews(int id)
        {
            return await _newsRepository.ExistAsync(id);
        }

        public async Task<IEnumerable<News>> GetAllNews()
        {
            var news = await _newsRepository.GetAllAsync();

            return news;
        }

        public async Task<IEnumerable<News>> GetNewsByCategoryId(int id)
        {
            var news = await _newsRepository.GetNewsByCategoryIdAsync(id);

            return news;
        }

        public async Task<News> GetNewsById(int id)
        {
            return await _newsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<News>> GetLatestToOldest()
        {
            var news = await _newsRepository.GetLatestToOldestAsync();

            return news;
        }

        public async Task<News> UpdateNews(NewsDto news)
        {
            var result = _mapper.Map<News>(news);
            return await _newsRepository.UpdateAsync(result);
        }

        public async Task<IEnumerable<News>> GetNewsByTittle(string tittle)
        {
            IEnumerable<News> news = await _newsRepository.GetAllAsync();
            List<News> List = new List<News>();

            if (tittle == null) return null;

            foreach (News item in news)
            {
                if (item.NewsTittle.Contains(tittle))
                {
                    List.Add(item);
                }
            }

            return List;
        }

        public async Task<IEnumerable<News>> GetNewsByCategoryName(string categoryName)
        {
            IEnumerable<News> news = await _newsRepository.GetAllAsync();

            if (categoryName == null) return null;

            return news;
        }
    }
}
