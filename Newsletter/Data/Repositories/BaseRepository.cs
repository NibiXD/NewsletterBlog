using Microsoft.EntityFrameworkCore;
using Newsletter.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<T> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var news = await _dbSet.FindAsync(id);
            _dbSet.Remove(news);
            return _context.SaveChanges() > 0;

        }

        public async Task<bool> ExistAsync(int id)
        {
            bool result = await _dbSet.AnyAsync(o => o.Id == id);
            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> query = _dbSet;

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T result = await _dbSet.FirstOrDefaultAsync(o => o.Id == id);

            return result;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
