using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.FileVariants;

public interface IFileVariantRepository : IFileVariantReadOnlyRepository, IWriteRepository<FileVariant, Guid>
{
}
