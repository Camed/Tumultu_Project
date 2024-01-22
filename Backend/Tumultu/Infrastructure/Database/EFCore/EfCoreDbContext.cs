using Microsoft.EntityFrameworkCore;
using Tumultu.Domain.Entities;

namespace Tumultu.Infrastructure.Database.EFCore;

public class EfCoreDbContext : DbContext
{
    public EfCoreDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public required DbSet<AnalysisResult> AnalysisResult { get; init; }

    public required DbSet<Behaviour> Behaviour { get; init; }

    public required DbSet<FileEntity> FileEntity { get; init; }

    public required DbSet<FileVariant> FileVariant { get; init; }

    public required DbSet<User> User { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfCoreDbContext).Assembly);
    }
}