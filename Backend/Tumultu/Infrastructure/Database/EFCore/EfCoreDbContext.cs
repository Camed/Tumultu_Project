using Microsoft.EntityFrameworkCore;
using Tumultu.Domain.Entities;

namespace Tumultu.Infrastructure.Database.EFCore;

public class EfCoreDbContext : DbContext
{
    public EfCoreDbContext(DbContextOptions options) 
        : base(options)
    {
    }

    public required DbSet<AnalysisResult> AnalysisResults { get; init; }
    
    public required DbSet<Behaviour> Behaviours { get; init; }
    
    public required DbSet<FileEntity> Files { get; init; }
    
    public required DbSet<FileVariant> FileVariants { get; init; }
    
    public required DbSet<User> Users { get; init; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfCoreDbContext).Assembly);
    }
}