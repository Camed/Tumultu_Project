using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.FileVariants.Commands;

public interface IFileVariantsRepository : IRepository<FileVariant, Guid>
{
    
}