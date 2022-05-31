using Microsoft.EntityFrameworkCore;
using Newsletter.Models;
using System.Collections.Generic;
using System.Linq;

namespace Newsletter.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly NewsletterContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(NewsletterContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public bool Delete(int id)
        {
            var news = _dbSet.Find(id);
            _dbSet.Remove(news);
            return _context.SaveChanges() > 0;

        }

        public bool Exist(int id)
        {
            bool result = _dbSet.Any(o => o.Id == id);
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbSet.OrderBy(o => o.Id);

            return query.ToList();
        }

        public T GetById(int id)
        {
            T result = _dbSet.FirstOrDefault(o => o.Id == id);

            return result;
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
