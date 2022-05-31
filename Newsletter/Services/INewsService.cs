using Newsletter.Models;
using System.Collections.Generic;

namespace Newsletter.Services
{
    public interface INewsService
    {
        News AddNews(News news);
        News UpdateNews(News news);
        bool ExistNews(int id);
        bool DeleteNews(int id);
        IEnumerable<News> GetAllNews();
        News GetNewsById(int id);
        IEnumerable<News> GetNewsByCategoryId(int id);
        IEnumerable<News> GetOldestToLatest();
        IEnumerable<News> GetLatestToOldest();
        News GetNewsByTittle(string tittle);
        News GetNewsByCategoryName(string categoryName);
    }
}
