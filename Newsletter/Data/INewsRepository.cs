
using Newsletter.Models;
using System.Collections.Generic;

namespace Newsletter.Data
{
    public interface INewsRepository : IBaseRepository<News>
    {
        News GetNewsById(int id);
        IEnumerable<News> GetNewsByCategoryId(int id);
        IEnumerable<News> GetOldestToLatest();
        IEnumerable<News> GetLatestToOldest();
        IEnumerable<News> GetNewsByTittle(string tittle);
        IEnumerable<News> GetNewsByCategoryName(string categoryName);
    }
}
