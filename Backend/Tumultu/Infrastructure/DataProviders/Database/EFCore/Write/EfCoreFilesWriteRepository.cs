using Microsoft.EntityFrameworkCore;
using Tumultu.Application.Files;
using Tumultu.Domain.Entities;

namespace Tumultu.Infrastructure.DataProviders.Database.EFCore.Write;

public class EfCoreFilesWriteRepository : EfCoreWriteRepository<FileEntity, Guid>, IFilesWriteRepository
{
    public EfCoreFilesWriteRepository(DbContext context) : base(context)
    {
    }
}