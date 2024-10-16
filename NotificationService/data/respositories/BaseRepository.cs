using Microsoft.EntityFrameworkCore;
using NotificationService.data.Models;
using NotificationService.interfaces;
using System.Linq.Expressions;

namespace NotificationService.data.respositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        private readonly TmpContext _tmpContext;

        public BaseRepository(TmpContext tmpContext)
        {
            _tmpContext = tmpContext;
        }
        public async Task<IReadOnlyList<Entity>> GetAllAsync()
        {
            var entities = await _tmpContext.Set<T>().ToListAsync();
            return entities.AsReadOnly();
        }
        public Task<List<TEntity>> GetAllAsync<TEntity>(Func<IQueryable<TEntity>,
            IQueryable<TEntity>> includeFunc,
            Expression<Func<TEntity, bool>>? predicate = null
            ) where TEntity : Entity
        {
            var query = _tmpContext.Set<TEntity>().AsQueryable();

            query = includeFunc(query);

            if (predicate != null) query = query.Where(predicate);

            return query.ToListAsync();
        }
        public async Task<T> UpdateAsync(T entity)
        { 
            _tmpContext.Entry(entity).State = EntityState.Modified;
            await _tmpContext.SaveChangesAsync();
            return entity;
        }

    }
}
