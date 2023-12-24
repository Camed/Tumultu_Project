using Microsoft.EntityFrameworkCore;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Common;

namespace Tumultu.Infrastructure.DataProviders.Database.EFCore.Write;

public class EfCoreWriteRepository<TEntity, TId> : IWriteRepository<TEntity, TId> where TEntity : BaseEntity<TId>
{
    private readonly DbContext _context;

    protected EfCoreWriteRepository(DbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TId id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public void Insert(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public void InsertMany(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().AddRange(entities);
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public void DeleteMany(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}