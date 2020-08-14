using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace app_enquete.Repositories
{
    public interface IRepositorio<T> : IDisposable
    {
        Task<IEnumerable<T>> Gets();
        Task<T> Get(int id);
        Task Insert(T entity);
        Task Delete(int id);
        Task Delete(T entityToDelete);
        Task Update(T entity);
        Task<int> Save();
        void SetLazyLoader(bool lazyLoader);
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        Task<IEnumerable<T>> Gets(string includeProperties = "");
        Task<T> Get(int id, string includeProperties = "");
        Task<T> Get(Expression<Func<T, bool>> filter = null,  string includeProperties = "");

        Task<int> GetCount(Expression<Func<T, bool>> filter = null);

    }
}
