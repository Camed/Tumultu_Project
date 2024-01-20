using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Behaviours.Commands;

public record DeleteBehaviourCommand(int Id) : IRequest;

public class DeleteBehaviourCommandHandler : IRequestHandler<DeleteBehaviourCommand>
{
    private readonly IBehaviourRepository _repository;

    public DeleteBehaviourCommandHandler(IBehaviourRepository behaviourRepository)
    {
        _repository = behaviourRepository;
    }

    public async Task Handle(DeleteBehaviourCommand request, CancellationToken cancellationToken)
    {
        Behaviour? entity = await _repository.GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        _repository.Delete(entity);

        entity.AddDomainEvent(new BehaviourDeletedEvent(entity));

        await _repository.SaveChangesAsync(cancellationToken);
    }
}