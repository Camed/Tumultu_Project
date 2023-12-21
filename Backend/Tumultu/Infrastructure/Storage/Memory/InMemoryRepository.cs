using Ardalis.GuardClauses;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Common;

namespace Tumultu.Infrastructure.Storage.Memory;

public class InMemoryRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : BaseEntity<TId>
{
    private static readonly List<TEntity> Data = [];

    public Task<IEnumerable<TEntity>> GetAllAsync(Func<TEntity, bool>? filter = null, Func<TEntity, TId>? orderBy = null)
    {
        IEnumerable<TEntity> entities = Data;

        if (filter is not null)
        {
            entities = entities.Where(filter);
        }

        if (orderBy is not null)
        {
            entities = entities.OrderBy(orderBy);
        }

        return Task.FromResult<IEnumerable<TEntity>>(entities.ToList());
    }

    public Task<TEntity?> GetByIdAsync(TId id)
    {
        Guard.Against.Null(id);
        TEntity? entity = Data.Find(entity => id.Equals(entity.Id));
        return Task.FromResult(entity);
    }

    public void Insert(TEntity entity)
    {
        Data.Add(entity);
    }

    public void InsertAll(IEnumerable<TEntity> entities)
    {
        Data.AddRange(entities);
    }

    public void Delete(TEntity entity)
    {
        Data.Remove(entity);
    }

    public void DeleteAll(IEnumerable<TEntity> entities)
    {
        foreach (TEntity entity in entities)
        {
            Data.Remove(entity);
        }
    }

    public void Update(TEntity entity)
    {
        TEntity? toBeUpdated = Data.SingleOrDefault(e => entity.Equals(e.Id));

        if (toBeUpdated is not null) Delete(toBeUpdated);

        Insert(entity);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}