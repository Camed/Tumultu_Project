using MediatR;
using Tumultu.Application.Interfaces.Common;

namespace Tumultu.Application.Behaviours.Commands;

public record CreateBehaviourCommand : IRequest<int>;

public class CreateBehaviourCommandHandler : IRequestHandler<CreateBehaviourCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateBehaviourCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(CreateBehaviourCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}