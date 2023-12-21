using Ardalis.GuardClauses;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Common;

namespace Tumultu.Infrastructure.DataProviders.Memory.Read;

public abstract class InMemoryReadOnlyRepository<TEntity, TId> : IReadOnlyRepository<TEntity, TId> where TEntity: BaseEntity<TId>
{
    public Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<TEntity>>(InMemoryData<TEntity>.Data.ToList());
    }

    public Task<TEntity?> GetByIdAsync(TId id)
    {
        Guard.Against.Null(id);
        TEntity? entity = InMemoryData<TEntity>.Data.Find(entity => id.Equals(entity.Id));
        return Task.FromResult(entity);
    }
}