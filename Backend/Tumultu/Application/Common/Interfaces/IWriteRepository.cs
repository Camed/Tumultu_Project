using Tumultu.Domain.Common;

namespace Tumultu.Application.Common.Interfaces;

public interface IWriteRepository<TEntity, TId> where TEntity : BaseEntity<TId>
{
    void Insert(TEntity entity);

    void InsertAll(IEnumerable<TEntity> entities);

    void Delete(TEntity entity);

    void DeleteAll(IEnumerable<TEntity> entities);

    void Update(TEntity entity);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}