using Microsoft.EntityFrameworkCore;
using Tumultu.Application.FileVariants;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.Database.EFCore.Repositories.Common;

namespace Tumultu.Infrastructure.Database.EFCore.Repositories.FileVariants;

internal class FileVariantRepository : EfCoreRepositoryBase<FileVariant, Guid>, IFileVariantRepository
{
    public FileVariantRepository(EfCoreDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<FileVariant>> GetAllFileVariantsByFile(FileEntity file)
    {
        return await Context.Set<FileVariant>()
            .Where(fileVariant => file.Equals(fileVariant.File))
            .ToListAsync();
    }
}