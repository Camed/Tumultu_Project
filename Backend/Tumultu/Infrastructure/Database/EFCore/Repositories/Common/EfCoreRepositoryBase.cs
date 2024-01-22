using Microsoft.EntityFrameworkCore;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Common;

namespace Tumultu.Infrastructure.Database.EFCore.Repositories.Common;

internal class EfCoreRepositoryBase<TEntity, TId> : IRepository<TEntity, TId> where TEntity : BaseEntity<TId>
{
    protected readonly EfCoreDbContext Context;

    protected EfCoreRepositoryBase(EfCoreDbContext context)
    {
        Context = context;
    }
    
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TId id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }

    public void Insert(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
    }

    public void InsertMany(IEnumerable<TEntity> entities)
    {
        Context.Set<TEntity>().AddRange(entities);
    }

    public void Delete(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }

    public void DeleteMany(IEnumerable<TEntity> entities)
    {
        Context.Set<TEntity>().RemoveRange(entities);
    }

    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }
}