using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Files;

public interface IFilesReadOnlyRepository : IReadOnlyRepository<FileEntity, Guid>
{
    Task<IEnumerable<FileEntity>> GetAllByAnySignature(string? md5Signature, string? sha1Signature, string? sha256Signature);
}
