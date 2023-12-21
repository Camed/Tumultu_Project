using Ardalis.GuardClauses;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Common;

namespace Tumultu.Infrastructure.DataProviders.Memory;

public abstract class InMemoryRepository<TEntity,TId> : IRepository<TEntity,TId> where TEntity: BaseEntity<TId>
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

    public void Insert(TEntity entity)
    {
        InMemoryData<TEntity>.Data.Add(entity);
    }

    public void InsertAll(IEnumerable<TEntity> entities)
    {
        InMemoryData<TEntity>.Data.AddRange(entities);
    }

    public void Delete(TEntity entity)
    {
        InMemoryData<TEntity>.Data.Remove(entity);
    }

    public void DeleteAll(IEnumerable<TEntity> entities)
    {
        foreach (TEntity entity in entities)
        {
            InMemoryData<TEntity>.Data.Remove(entity);
        }
    }

    public void Update(TEntity entity)
    {
        TEntity? toBeUpdated =  InMemoryData<TEntity>.Data.Find(e => entity.Equals(e.Id));

        if (toBeUpdated is not null) Delete(toBeUpdated);

        Insert(entity);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}