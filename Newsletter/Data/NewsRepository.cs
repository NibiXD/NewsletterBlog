using Newsletter.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Newsletter.Data
{
    public class NewsRepository : BaseRepository<News>, INewsRepository
    {
        private readonly DbSet<News> _dbSet;

        public NewsRepository(NewsletterContext context) : base(context)
        {
            _dbSet = context.News;
        }

        public IEnumerable<News> GetLatestToOldest()
        {
            IQueryable<News> news = _dbSet.OrderBy(n => n.PublishDate).Include(n => n.Category);

            return news.ToList();
        }

        public News GetNewsById(int id)
        {
            var news = _dbSet.Include(n => n.Category).FirstOrDefault(n => n.Id == id);

            return news;
        }

        public IEnumerable<News> GetNewsByCategoryId(int id)
        {
            IQueryable<News> news = _dbSet.Where(n => n.CategoryId == id).Include(n => n.Category);

            return news.ToList();
        }

        public IEnumerable<News> GetOldestToLatest()
        {
            IQueryable<News> news = _dbSet.OrderByDescending(n => n.PublishDate).Include(n => n.Category);

            return news.ToList();
        }

        public IEnumerable<News> GetNewsByTittle(string tittle)
        {
            IQueryable<News> news = _dbSet.Where(n => n.NewsTittle.ToLower().Contains(tittle.ToLower())).Include(n => n.Category);

            return news;
        }

        public IEnumerable<News> GetNewsByCategoryName(string categoryName)
        {
            IQueryable<News> news = _dbSet.Include(c => c.Category).Where(cn => cn.Category.Name.Contains(categoryName));

            return news;
        }
    }
}
