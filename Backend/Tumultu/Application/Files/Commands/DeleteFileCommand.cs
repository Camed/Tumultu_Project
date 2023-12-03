using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Interfaces.Common;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Files.Commands;

public record DeleteFileCommand(Guid Id) : IRequest;

public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteFileCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteFileCommand request, CancellationToken token)
    {
        var entity = await _context.Files
            .FindAsync(new object[] { request.Id }, token);

        Guard.Against.NotFound(request.Id, entity);

        _context.Files.Remove(entity);

        entity.AddDomainEvent(new FileDeletedEvent(entity));

        await _context.SaveChangesAsync(token);
    }
}