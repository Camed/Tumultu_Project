using Tumultu.Domain.Common;

namespace Tumultu.Application.Common.Interfaces;

public interface IEntityRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    Task<TEntity?> GetByIdAsync(TKey id);
    Task<IEnumerable<TEntity>> GetAllAsync();
}
