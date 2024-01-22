using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Behaviours.Commands;

public record DeleteBehaviourCommand(int Id) : IRequest;

public class DeleteBehaviourCommandHandler : IRequestHandler<DeleteBehaviourCommand>
{
    private readonly IBehaviourRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBehaviourCommandHandler(IBehaviourRepository behaviourRepository, IUnitOfWork unitOfWork)
    {
        _repository = behaviourRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteBehaviourCommand request, CancellationToken cancellationToken)
    {
        Behaviour? entity = await _repository.GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        _repository.Delete(entity);

        entity.AddDomainEvent(new BehaviourDeletedEvent(entity));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}