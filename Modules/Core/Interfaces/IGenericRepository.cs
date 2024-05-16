using System.Linq.Expressions;
using Rygio.Core.Helper.pagination;

namespace Ripple.API.Modules.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class, new()
    {
        PageList<T> GetAll(PageParameter pagination);
        PageList<T> GetAll(Expression<Func<T, bool>> predicate, PageParameter pagination);
        PageList<T> GetAll(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderBy, PageParameter pagination);
        PageList<T> GetAll(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderBy, PageParameter pagination, params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> GetAll();
        Task<int> CountWhere(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetSingle(Expression<Func<T, bool>> predicate);
        Task<T> GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> Add(T entity);
        Task<List<T>> Add(List<T> entities);
        void Update(T entity);
        void Update(List<T> entities);
        void Delete(T entity);
        void Delete(List<T> entities);
        void Clear();
        Task CommitAsync();
    }
}
