using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Interfaces.Common;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Files.Commands;

public record DeleteAnalysisResultCommand(Guid Id) : IRequest;

public class DeleteAnalysisResultCommandHandler : IRequestHandler<DeleteAnalysisResultCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteAnalysisResultCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteAnalysisResultCommand request, CancellationToken token)
    {
        AnalysisResult? entity = await _context.AnalysisResults
            .FindAsync(new object[] { request.Id }, token);

        Guard.Against.NotFound(request.Id, entity);

        _context.AnalysisResults.Remove(entity);

        entity.AddDomainEvent(new AnalysisDeletedEvent(entity));

        await _context.SaveChangesAsync(token);
    }
}