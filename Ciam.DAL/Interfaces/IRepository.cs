using System;
using System.Linq;

namespace Ciam.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> Filter(Func<T, Boolean> predicate);

        void Create(T item);

        void Update(T item);

        void Delete(Func<T, Boolean> predicate);
    }
}
