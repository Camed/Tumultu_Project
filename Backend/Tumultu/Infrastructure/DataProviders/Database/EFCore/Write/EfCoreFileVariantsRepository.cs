using Microsoft.EntityFrameworkCore;
using Tumultu.Application.FileVariants.Commands;
using Tumultu.Domain.Entities;

namespace Tumultu.Infrastructure.DataProviders.Database.EFCore.Write;

public class EfCoreFileVariantsRepository : EfCoreRepository<FileVariant, Guid>, IFileVariantsRepository
{
    public EfCoreFileVariantsRepository(DbContext context) : base(context)
    {
    }
}