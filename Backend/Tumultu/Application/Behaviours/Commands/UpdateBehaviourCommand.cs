using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Interfaces.Common;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Behaviours.Commands;

public record UpdateBehaviourCommand(int Id) : IRequest;

public class UpdateBehaviourCommandHandler : IRequestHandler<UpdateBehaviourCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateBehaviourCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateBehaviourCommand request, CancellationToken cancellationToken)
    {
        Behaviour? entity = await _context.Behaviours
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        // change anything in entity

        await _context.SaveChangesAsync(cancellationToken);
    }
}