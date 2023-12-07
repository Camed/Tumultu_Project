using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Interfaces.Common;

namespace Tumultu.Application.Files.Commands;

public record class UpdateFileCommand : IRequest
{
    public Guid Id { get; init; }
}

public class UpdateFileCommandHandler : IRequestHandler<UpdateFileCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateFileCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateFileCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Files
            .FindAsync(new object[] {  request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        // change anything in entity

        await _context.SaveChangesAsync(cancellationToken);
    }
}