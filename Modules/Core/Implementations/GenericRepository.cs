
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using Ripple.API.Modules.Core.Interfaces;
using Rygio.Core.Helper.pagination;

namespace Ripple.API.Modules.Core.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private readonly AppDbContext context;


        public GenericRepository(AppDbContext context)
        {
            this.context = context;
            this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this.context.ChangeTracker.LazyLoadingEnabled = false;

        }

        public async Task<T> Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<List<T>> Add(List<T> entities)
        {
            await context.Set<T>().AddRangeAsync(entities);
            return entities;
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            EntityEntry dbEntityEntry = context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }
        public void Clear()
        {
            context.ChangeTracker.Clear();
        }

        public void Delete(List<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }

        public PageList<T> GetAll(PageParameter pagination)
        {
            return PageList<T>.ToPagedList(context.Set<T>(), pagination.PageNumber, pagination.PageSize);
        }

        public PageList<T> GetAll(Expression<Func<T, bool>> predicate, PageParameter pagination)
        {
            return PageList<T>.ToPagedList(context.Set<T>().Where(predicate), pagination.PageNumber, pagination.PageSize);
        }

        public PageList<T> GetAll(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderBy, PageParameter pagination)
        {
            return PageList<T>.ToPagedList(context.Set<T>().Where(predicate).OrderByDescending(orderBy), pagination.PageNumber, pagination.PageSize);
        }

        public PageList<T> GetAll(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderBy, PageParameter pagination, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return PageList<T>.ToPagedList(query.Where(predicate).OrderByDescending(orderBy), pagination.PageNumber, pagination.PageSize);
        }
        public virtual async Task<int> CountWhere(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }


            return await query.Where(predicate).CountAsync();
        }
        public Task<List<T>> GetAll()
        {
            return context.Set<T>().ToListAsync();
        }

        public Task<List<T>> GetAll(Expression<Func<T, bool>> predicate)
        {

            return context.Set<T>().Where(predicate).ToListAsync();
        }

        public Task<List<T>> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> query = context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.Where(predicate).ToListAsync();
        }

        public Task<List<T>> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.ToListAsync();
        }

        public Task<T> GetSingle(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().FirstOrDefaultAsync(predicate)!;
        }

        public Task<T> GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefaultAsync()!;
        }

        public void Update(T entity)
        {
            EntityEntry dbEntityEntry = context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Update(List<T> entities)
        {
            context.Set<T>().UpdateRange(entities);
        }
    }
}
