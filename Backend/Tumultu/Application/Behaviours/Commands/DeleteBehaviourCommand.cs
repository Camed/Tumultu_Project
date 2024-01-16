using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Behaviours.Commands;

public record DeleteBehaviourCommand(int Id) : IRequest;

public class DeleteBehaviourCommandHandler : IRequestHandler<DeleteBehaviourCommand>
{
    private readonly IBehaviourReadRepository _readRepository;
    private readonly IWriteRepository<Behaviour, int> _writeRepository;

    public DeleteBehaviourCommandHandler(IBehaviourReadRepository readRepository, IWriteRepository<Behaviour, int> writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task Handle(DeleteBehaviourCommand request, CancellationToken cancellationToken)
    {
        Behaviour? entity = await _readRepository.GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        _writeRepository.Delete(entity);

        entity.AddDomainEvent(new BehaviourDeletedEvent(entity));

        await _writeRepository.SaveChangesAsync(cancellationToken);
    }
}