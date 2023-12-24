using Microsoft.EntityFrameworkCore;

namespace Tumultu.Infrastructure.DataProviders.Database.EFCore;

public sealed class EfCoreDbContext : DbContext, IEfCoreDbContext
{
    public EfCoreDbContext(DbContextOptions<EfCoreDbContext> options)
        : base(options)
    {
    }
}