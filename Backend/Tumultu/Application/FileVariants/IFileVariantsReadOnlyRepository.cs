using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.FileVariants;

public interface IFileVariantsReadOnlyRepository : IReadOnlyRepository<FileVariant,  Guid>
{
    Task<IEnumerable<FileVariant>> GetAllFileVariantsByFile(FileEntity file);
}
