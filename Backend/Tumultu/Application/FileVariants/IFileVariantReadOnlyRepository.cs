using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.FileVariants;

public interface IFileVariantReadOnlyRepository : IReadOnlyRepository<FileVariant,  Guid>
{
    Task<IEnumerable<FileVariant>> GetAllFileVariantsByFile(FileEntity file);
}
