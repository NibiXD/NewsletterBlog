using Newsletter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Newsletter.Services
{
    public interface INewsService
    {
        Task<News> AddNews(News news);
        Task<News> UpdateNews(News news);
        Task<bool> ExistNews(int id);
        Task<bool> DeleteNews(int id);
        Task<IEnumerable<News>> GetAllNews();
        Task<News> GetNewsById(int id);
        Task<IEnumerable<News>> GetNewsByCategoryId(int id);
        Task<IEnumerable<News>> GetLatestToOldest();
        Task<IEnumerable<News>> GetNewsByTittle(string tittle);
        Task<IEnumerable<News>> GetNewsByCategoryName(string categoryName);
    }
}
