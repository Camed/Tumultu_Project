using MediatR;

namespace Tumultu.Application.FileVariants.Commands;

public record CreateFileVariantCommand : IRequest<Guid>
{
}

public class CreateFileVariantCommandHander : IRequestHandler<CreateFileVariantCommand, Guid>
{
    private readonly IFileVariantsRepository _repository;

    public CreateFileVariantCommandHander(IFileVariantsRepository repository)
    {
        _repository = repository;
    }

    public Task<Guid> Handle(CreateFileVariantCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}