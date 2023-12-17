using Tumultu.Domain.Common;

namespace Tumultu.Application.Common.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey> 
    {
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TKey id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TKey id);
        Task<TEntity> FindAsync(TKey id);
    }
}
