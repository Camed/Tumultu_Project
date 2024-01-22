using Microsoft.EntityFrameworkCore;
using Tumultu.Application.Files;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.Database.EFCore.Repositories.Common;

namespace Tumultu.Infrastructure.Database.EFCore.Repositories.Files;

internal class FileRepository : EfCoreRepositoryBase<FileEntity, Guid>, IFileRepository
{
    public FileRepository(EfCoreDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<FileEntity>> GetAllByAnySignature(string? md5Signature, string? sha1Signature, string? sha256Signature)
    {
        return await Context.Set<FileEntity>()
            .Where(file =>
                file.MD5Signature == md5Signature
                || file.SHA1Signature == sha1Signature
                || file.SHA256Signature == sha256Signature)
            .ToListAsync();
    }
}