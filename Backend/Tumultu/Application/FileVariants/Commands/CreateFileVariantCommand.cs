using MediatR;

namespace Tumultu.Application.FileVariants.Commands;

public record CreateFileVariantCommand : IRequest<Guid>
{
}

public class CreateFileVariantCommandHander : IRequestHandler<CreateFileVariantCommand, Guid>
{
    private readonly IFileVariantsWriteRepository _writeRepository;

    public CreateFileVariantCommandHander(IFileVariantsWriteRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public Task<Guid> Handle(CreateFileVariantCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}