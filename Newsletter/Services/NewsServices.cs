using Newsletter.Models;
using System.Collections.Generic;
using Newsletter.Data;
using System.Threading.Tasks;

namespace Newsletter.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly ISubscriberRepository _userRepository;
        private readonly EmailSenderService _emailSenderService;

        public NewsService(INewsRepository newsRepository, EmailSenderService emailSenderService, ISubscriberRepository userRepository)
        {
            _newsRepository = newsRepository;
            _emailSenderService = emailSenderService;
            _userRepository = userRepository;
        }

        public async Task<News> AddNews(News news)
        {
            await _newsRepository.AddAsync(news);
            IEnumerable<Subscriber> user = await _userRepository.GetAllAsync();

            foreach (Subscriber userItem in user)
            {
                _emailSenderService.SendMail(userItem.Email, news);
            }

            return news;
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
            return await _newsRepository.GetNewsByIdAsync(id);
        }

        public async Task<IEnumerable<News>> GetLatestToOldest()
        {
            var news = await _newsRepository.GetLatestToOldestAsync();

            return news;
        }

        public async Task<News> UpdateNews(News news)
        {
            return await _newsRepository.UpdateAsync(news);
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
