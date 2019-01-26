using Ciam.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Ciam.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        private readonly DbSet<T> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Create(T item)
        {
            _dbSet.Add(item);
        }

        public void Delete(Func<T, bool> predicate)
        {
            var entitiesToDelete = _dbSet.Where(predicate).AsQueryable();

            foreach (T entity in entitiesToDelete)
            {
                if (_dbContext.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }

                _dbSet.Remove(entity);
            }
        }

        public IQueryable<T> Filter(Func<T, bool> predicate)
        {
            return _dbSet.Where(predicate).AsQueryable();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public void Update(T item)
        {
            if (item == null)
            {
                throw new ArgumentException("Невозможно обновить пустую модель.");
            }

            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
