using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Common;

namespace Tumultu.Infrastructure.DataProviders.Memory.Write;

public abstract class InMemoryWriteRepository<TEntity,TId> : IWriteRepository<TEntity,TId> where TEntity: BaseEntity<TId>
{
    public void Insert(TEntity entity)
    {
        InMemoryData<TEntity>.Data.Add(entity);
    }

    public void InsertMany(IEnumerable<TEntity> entities)
    {
        InMemoryData<TEntity>.Data.AddRange(entities);
    }

    public void Delete(TEntity entity)
    {
        InMemoryData<TEntity>.Data.Remove(entity);
    }

    public void DeleteMany(IEnumerable<TEntity> entities)
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