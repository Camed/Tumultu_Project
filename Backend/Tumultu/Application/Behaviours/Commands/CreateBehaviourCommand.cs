using MediatR;

namespace Tumultu.Application.Behaviours.Commands;

public record CreateBehaviourCommand : IRequest<int>;

public class CreateBehaviourCommandHandler : IRequestHandler<CreateBehaviourCommand, int>
{

    private readonly IBehaviourRepository _repository;

    public CreateBehaviourCommandHandler(IBehaviourRepository behaviourRepository)
    {
        _repository = behaviourRepository;
    }

    public Task<int> Handle(CreateBehaviourCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}