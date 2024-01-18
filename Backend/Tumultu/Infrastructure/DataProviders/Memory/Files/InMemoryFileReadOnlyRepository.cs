using Tumultu.Application.Files;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.DataProviders.Memory.Common;

namespace Tumultu.Infrastructure.DataProviders.Memory.Files;

public class InMemoryFileReadOnlyRepository : InMemoryReadOnlyRepository<FileEntity, Guid>, IFileReadOnlyRepository
{
    public Task<IEnumerable<FileEntity>> GetAllByAnySignature(string? md5Signature, string? sha1Signature,
        string? sha256Signature)
    {
        IEnumerable<FileEntity> filesWithSameSignature = InMemoryData<FileEntity>.Data.Where(file =>
            file.MD5Signature == md5Signature
            || file.SHA1Signature == sha1Signature
            || file.SHA256Signature == sha256Signature);

        return Task.FromResult<IEnumerable<FileEntity>>(filesWithSameSignature.ToList());
    }
}

