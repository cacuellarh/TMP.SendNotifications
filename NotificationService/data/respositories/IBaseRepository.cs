using NotificationService.interfaces;
using System.Linq.Expressions;

namespace NotificationService.data.respositories
{
    public interface IBaseRepository<T> where T : Entity
    {

        public Task<IReadOnlyList<Entity>> GetAllAsync();
        public Task<List<TEntity>> GetAllAsync<TEntity>(Func<IQueryable<TEntity>,
            IQueryable<TEntity>> includeFunc,
            Expression<Func<TEntity, bool>>? predicate = null
            ) where TEntity : Entity;
        public  Task<T> UpdateAsync(T entity);
    }
}
