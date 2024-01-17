using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Files;

public interface IFilesRepository : IFilesReadOnlyRepository, IWriteRepository<FileEntity, Guid>
{
}