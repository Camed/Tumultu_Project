using Tumultu.Application.Common.Interfaces;

namespace Tumultu.Application.FileVariants.Repositories;

public interface IFileVariantsRepository : IEntityRepository<FileVariant, Guid>
{
}
