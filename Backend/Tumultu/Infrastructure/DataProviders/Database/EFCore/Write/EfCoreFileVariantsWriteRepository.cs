using Microsoft.EntityFrameworkCore;
using Tumultu.Application.FileVariants;
using Tumultu.Domain.Entities;

namespace Tumultu.Infrastructure.DataProviders.Database.EFCore.Write;

public class EfCoreFileVariantsWriteRepository : EfCoreWriteRepository<FileVariant, Guid>, IFileVariantsWriteRepository
{
    public EfCoreFileVariantsWriteRepository(DbContext context) : base(context)
    {
    }
}