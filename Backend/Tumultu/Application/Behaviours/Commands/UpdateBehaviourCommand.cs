using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Behaviours.Commands;

public record UpdateBehaviourCommand(int Id) : IRequest;

public class UpdateBehaviourCommandHandler : IRequestHandler<UpdateBehaviourCommand>
{
    private readonly IBehaviourRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBehaviourCommandHandler(IBehaviourRepository behaviourRepository, IUnitOfWork unitOfWork)
    {
        _repository = behaviourRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateBehaviourCommand request, CancellationToken cancellationToken)
    {
        Behaviour? entity = await _repository.GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        // change anything in entity

        _repository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}