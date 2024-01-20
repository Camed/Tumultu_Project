using Microsoft.EntityFrameworkCore;
using Tumultu.Application.FileVariants;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.DataProviders.EFCore.Common;

namespace Tumultu.Infrastructure.DataProviders.EFCore.FileVariants;

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