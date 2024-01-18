using Tumultu.Domain.Common;

namespace Tumultu.Application.Common.Interfaces;

public interface IWriteRepository<TEntity, TId> where TEntity : BaseEntity<TId>
{
    void Insert(TEntity entity);

    void InsertMany(IEnumerable<TEntity> entities);

    void Delete(TEntity entity);

    void DeleteMany(IEnumerable<TEntity> entities);

    void Update(TEntity entity);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}



