using Tumultu.Application.Files;
using Tumultu.Domain.Entities;

namespace Tumultu.Infrastructure.DataProviders.Memory.Write;

public class InMemoryFilesWriteRepository : InMemoryWriteRepository<FileEntity, Guid>, IFilesWriteRepository
{
}