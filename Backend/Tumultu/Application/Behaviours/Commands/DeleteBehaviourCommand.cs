using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Interfaces.Common;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Behaviours.Commands;

public record DeleteBehaviourCommand(int Id) : IRequest;

public class DeleteBehaviourCommandHandler : IRequestHandler<DeleteBehaviourCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteBehaviourCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteBehaviourCommand request, CancellationToken cancellationToken)
    {
        Behaviour? entity = await _context.Behaviours
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Behaviours.Remove(entity);

        entity.AddDomainEvent(new BehaviourDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}