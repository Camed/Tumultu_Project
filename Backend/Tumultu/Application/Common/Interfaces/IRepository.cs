using Tumultu.Domain.Common;

namespace Tumultu.Application.Common.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey> 
    {
        IQuerable<TEntity> GetAll(bool noTracking = true);
        Task<TEntity?> GetByIdAsync(Guid id);
        void Insert(TEntity entity);
        void Insert(IEnumberable<TEntity> entities);
        void Delete(TEntity entity);
        void Remove(IEnumerable<TEntity> entities);
    }
}
