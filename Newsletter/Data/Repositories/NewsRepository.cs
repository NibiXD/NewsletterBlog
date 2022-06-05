using Newsletter.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Newsletter.Data
{
    public class NewsRepository : INewsRepository
    {
        private readonly IBaseRepository<News> _baseRepository;
        private readonly NewsletterContext _context;
        private readonly DbSet<News> _dbSet;

        public NewsRepository(IBaseRepository<News> baseRepository, NewsletterContext newsletterContext)
        {
            _baseRepository = baseRepository;
            _context = newsletterContext;
            _dbSet = _context.News;
        }

        public async Task<IEnumerable<News>> GetLatestToOldestAsync()
        {
            IQueryable<News> news = _dbSet.OrderBy(n => n.PublishDate).Include(n => n.Category);

            return await news.ToListAsync();
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

        public async Task<News> AddAsync(News entity)
        {
            return await _baseRepository.AddAsync(entity);
        }

        public async Task<News> UpdateAsync(News entity)
        {
            return await _baseRepository.UpdateAsync(entity);
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _baseRepository.ExistAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<News>> GetAllAsync()
        {
            var result = await _dbSet.Include(o => o.Category).ToListAsync();

            return result;
        }

        public async Task<News> GetByIdAsync(int id)
        {
            var result = await _dbSet.Include(n => n.Category).FirstOrDefaultAsync(n => n.Id == id);

            return result;
        }
    }
}
