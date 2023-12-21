using Tumultu.Domain.Common;

namespace Tumultu.Application.Common.Interfaces;

public interface IReadOnlyRepository<TEntity, TId> where TEntity : BaseEntity<TId>
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity?> GetByIdAsync(TId id);
}