using Tumultu.Application.FileVariants;
using Tumultu.Domain.Entities;

namespace Tumultu.Infrastructure.DataProviders.Memory.Write;

public class InMemoryFileVariantsWriteRepository : InMemoryWriteRepository<FileVariant, Guid>, IFileVariantsWriteRepository
{
}