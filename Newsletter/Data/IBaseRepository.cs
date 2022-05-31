using Newsletter.Models;
using System.Collections.Generic;

namespace Newsletter.Data
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public T Add(T entity);
        public T Update(T entity);
        public bool Exist(int id);
        public bool Delete(int id);
        public IEnumerable<T> GetAll();
        public T GetById(int id);
    }
}
