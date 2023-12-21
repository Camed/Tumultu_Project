using Tumultu.Application.FileVariants.Commands;
using Tumultu.Domain.Entities;

namespace Tumultu.Infrastructure.DataProviders.Memory.Write;

public class InMemoryFileVariantsRepository : InMemoryRepository<FileVariant, Guid>, IFileVariantsRepository
{
}