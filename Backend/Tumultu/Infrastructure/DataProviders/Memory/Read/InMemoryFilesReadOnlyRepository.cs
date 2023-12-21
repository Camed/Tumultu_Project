using Tumultu.Application.Files.Queries;
using Tumultu.Domain.Entities;

namespace Tumultu.Infrastructure.DataProviders.Memory.Read;

public class InMemoryFilesReadOnlyRepository : InMemoryReadOnlyRepository<FileEntity, Guid>, IFilesReadOnlyRepository
{
    public Task<IEnumerable<FileEntity>> GetAllByAnySignature(string? md5Signature, string? sha1Signature, string? sha256Signature)
    {
        IEnumerable<FileEntity> filesWithSameSignature = InMemoryData<FileEntity>.Data.Where(file =>
            file.MD5Signature == md5Signature
            || file.SHA1Signature == sha1Signature
            || file.SHA256Signature == sha256Signature);

        return Task.FromResult<IEnumerable<FileEntity>>(filesWithSameSignature.ToList());
    }
}