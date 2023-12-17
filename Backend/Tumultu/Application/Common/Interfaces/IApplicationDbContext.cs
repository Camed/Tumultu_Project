using Microsoft.EntityFrameworkCore;
using Tumultu.Domain.Entities;
using Tumultu.Domain.ValueObjects;

namespace Tumultu.Application.Interfaces.Common;

public interface IApplicationDbContext
{
    DbSet<FileEntity> Files { get; }
    DbSet<FileNote> FileNotes { get; }
    DbSet<FileString> FileStrings { get; }
    DbSet<FileVariant> FileVariants { get; }
    DbSet<AnalysisResult> AnalysisResults { get; }
    DbSet<Behaviour> Behaviours { get; }
    DbSet<Signature> Signatures { get; }
    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    int SaveChanges(CancellationToken cancellationToken);
}
