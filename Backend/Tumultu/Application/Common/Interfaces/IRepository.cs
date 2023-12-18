using System.Linq;
using Tumultu.Domain.Common;

namespace Tumultu.Application.Common.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        IQueryable<TEntity> GetAll(bool noTracking = true);
        Task<TEntity?> GetByIdAsync(Guid id);
        void Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Remove(IEnumerable<TEntity> entities);
    }
}
