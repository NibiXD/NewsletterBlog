using Newsletter.Models;
using System.Collections.Generic;
using Newsletter.Data;

namespace Newsletter.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IUserRepository _userRepository;
        private readonly EmailSenderService _emailSenderService;

        public NewsService(INewsRepository newsRepository, EmailSenderService emailSenderService, IUserRepository userRepository)
        {
            _newsRepository = newsRepository;
            _emailSenderService = emailSenderService;
            _userRepository = userRepository;
        }

        public News AddNews(News news)
        {
            _newsRepository.Add(news);
            IEnumerable<User> user = _userRepository.GetAll();

            foreach (User userItem in user)
            {
                _emailSenderService.SendMail(userItem.Email, news);
            }

            return news;
        }

        public bool DeleteNews(int id)
        {
            return _newsRepository.Delete(id);
        }

        public bool ExistNews(int id)
        {
            return _newsRepository.Exist(id);
        }

        public IEnumerable<News> GetAllNews()
        {
            var news = _newsRepository.GetAll();

            return news;
        }

        public IEnumerable<News> GetLatestToOldest()
        {
            var news = _newsRepository.GetLatestToOldest();

            return news;
        }

        public IEnumerable<News> GetNewsByCategoryId(int id)
        {
            var news = _newsRepository.GetNewsByCategoryId(id);

            return news;
        }

        public News GetNewsById(int id)
        {
            return _newsRepository.GetNewsById(id);
        }

        public IEnumerable<News> GetOldestToLatest()
        {
            var news = _newsRepository.GetOldestToLatest();

            return news;
        }

        public News UpdateNews(News news)
        {
            return _newsRepository.Update(news);
        }

        public News GetNewsByTittle(string tittle)
        {
            IEnumerable<News> news = _newsRepository.GetAll();

            if (tittle == null) return null;

            foreach (News item in news)
            {
                if (item.NewsTittle.Contains(tittle))
                {
                    return item;
                }
            }
            return null;
        }

        public News GetNewsByCategoryName(string categoryName)
        {
            IEnumerable<News> news = _newsRepository.GetAll();

            if (categoryName == null) return null;

            return null;
        }
    }
}
