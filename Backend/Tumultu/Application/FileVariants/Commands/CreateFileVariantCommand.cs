using MediatR;
using Tumultu.Application.Interfaces.Common;

namespace Tumultu.Application.FileVariants.Commands;

public record CreateFileVariantCommand : IRequest<Guid>
{
}

public class CreateFileVariantCommandHander : IRequestHandler<CreateFileVariantCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    public CreateFileVariantCommandHander(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Guid> Handle(CreateFileVariantCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}