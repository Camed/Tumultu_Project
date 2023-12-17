using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.FileVariants.Commands;

public record CreateFileVariantCommand : IRequest<Guid>
{
}

public class CreateFileVariantCommandHander : IRequestHandler<CreateFileVariantCommand, Guid>
{
    private readonly IRepository<FileVariant, Guid> _repository;
    public CreateFileVariantCommandHander(IRepository<FileVariant, Guid> repository)
    {
        _repository = repository;
    }

    public Task<Guid> Handle(CreateFileVariantCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}