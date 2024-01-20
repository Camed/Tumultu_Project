using Microsoft.EntityFrameworkCore;
using Tumultu.Domain.Entities;

namespace Tumultu.Infrastructure.DataProviders.EFCore;

public class EfCoreDbContext : DbContext
{
    public EfCoreDbContext(DbContextOptions<EfCoreDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<AnalysisResult> AnalysisResults { get; set; }
    
    public DbSet<Behaviour> Behaviours { get; set; }
    
    public DbSet<FileEntity> Files { get; set; }
    
    public DbSet<FileVariant> FileVariants { get; set; }
    
    public DbSet<User> Users { get; set; }
    
}