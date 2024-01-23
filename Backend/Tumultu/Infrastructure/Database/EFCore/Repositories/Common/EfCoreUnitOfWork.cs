using Tumultu.Application.Common.Interfaces;

namespace Tumultu.Infrastructure.Database.EFCore.Repositories.Common;

internal class EfCoreUnitOfWork : IUnitOfWork
{
    private readonly EfCoreDbContext _context;

    public EfCoreUnitOfWork(EfCoreDbContext context)
    {
        _context = context;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}