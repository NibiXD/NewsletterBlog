using Newsletter.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Newsletter.Data
{
    public class NewsRepository : BaseRepository<News>, INewsRepository
    {
        private readonly DbSet<News> _dbSet;

        public NewsRepository(NewsletterContext context) : base(context)
        {
            _dbSet = context.News;
        }

        public async Task<IEnumerable<News>> GetLatestToOldestAsync()
        {
            IQueryable<News> news = _dbSet.OrderBy(n => n.PublishDate).Include(n => n.Category);

            return await news.ToListAsync();
        }

        public async Task<News> GetNewsByIdAsync(int id)
        {
            var news = await _dbSet.Include(n => n.Category).FirstOrDefaultAsync(n => n.Id == id);

            return news;
        }

        public async Task<IEnumerable<News>> GetNewsByCategoryIdAsync(int id)
        {
            IQueryable<News> news = _dbSet.Where(n => n.CategoryId == id).Include(n => n.Category);

            return await news.ToListAsync();
        }

        public async Task<IEnumerable<News>> GetNewsByTittleAsync(string tittle)
        {
            IQueryable<News> news = _dbSet.Where(n => n.NewsTittle.ToLower().Contains(tittle.ToLower())).Include(n => n.Category);

            return await news.ToListAsync();
        }

        public async Task<IEnumerable<News>> GetNewsByCategoryNameAsync(string categoryName)
        {
            IQueryable<News> news = _dbSet.Include(c => c.Category).Where(cn => cn.Category.Name.Contains(categoryName));

            return await news.ToListAsync();
        }
    }
}
