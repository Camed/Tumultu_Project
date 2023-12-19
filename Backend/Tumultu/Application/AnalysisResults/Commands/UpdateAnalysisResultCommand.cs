using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Interfaces.Common;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.AnalysisResults.Commands;

public record UpdateAnalysisResultCommand(Guid Id) : IRequest;

public class UpdateAnalysisResultCommandHandler : IRequestHandler<UpdateAnalysisResultCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateAnalysisResultCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateAnalysisResultCommand request, CancellationToken cancellationToken)
    {
        AnalysisResult? entity = await _context.AnalysisResults
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        // change anything in entity

        await _context.SaveChangesAsync(cancellationToken);
    }
}