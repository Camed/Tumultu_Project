using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Behaviours.Commands;

public record CreateBehaviourCommand : IRequest<int>;

public class CreateBehaviourCommandHandler : IRequestHandler<CreateBehaviourCommand, int>
{
    private readonly IBehaviourReadRepository _readRepository;
    private readonly IWriteRepository<Behaviour, int> _writeRepository;

    public CreateBehaviourCommandHandler(IBehaviourReadRepository readRepository, IWriteRepository<Behaviour, int> writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public Task<int> Handle(CreateBehaviourCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}