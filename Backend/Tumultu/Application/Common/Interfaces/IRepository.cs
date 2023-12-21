using Tumultu.Domain.Common;

namespace Tumultu.Application.Common.Interfaces;

public interface IRepository<TEntity, TId> where TEntity : BaseEntity<TId>
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity?> GetByIdAsync(TId id);
    
    void Insert(TEntity entity);

    void InsertAll(IEnumerable<TEntity> entities);

    void Delete(TEntity entity);

    void DeleteAll(IEnumerable<TEntity> entities);

    void Update(TEntity entity);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}