using Tumultu.Application.Common.Interfaces;

namespace Tumultu.Application.Files.Repositories;

public interface IFileEntitiesRepository : IEntityRepository<FileEntity, Guid>
{
}
