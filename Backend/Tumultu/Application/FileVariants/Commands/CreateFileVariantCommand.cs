using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.FileVariants.Commands;

public record CreateFileVariantCommand : IRequest<Guid>
{
}

public class CreateFileVariantCommandHander : IRequestHandler<CreateFileVariantCommand, Guid>
{
    private readonly IWriteRepository<FileVariant, Guid> _writeRepository;

    public CreateFileVariantCommandHander(IWriteRepository<FileVariant, Guid> writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public Task<Guid> Handle(CreateFileVariantCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}