
using Newsletter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Newsletter.Data
{
    public interface INewsRepository : IBaseRepository<News>
    {
        Task<IEnumerable<News>> GetNewsByCategoryIdAsync(int id);
        Task<IEnumerable<News>> GetLatestToOldestAsync();
        Task<IEnumerable<News>> GetNewsByTittleAsync(string tittle);
        Task<IEnumerable<News>> GetNewsByCategoryNameAsync(string categoryName);
    }
}
