using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Files.Repositories;

public interface IFileEntitiesRepository : IEntityRepository<FileEntity, Guid>
{
}
