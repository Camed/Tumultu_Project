using Tumultu.Application.Common.Interfaces;

namespace Tumultu.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork()
    {

    }

    public Task<bool> CommitAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
