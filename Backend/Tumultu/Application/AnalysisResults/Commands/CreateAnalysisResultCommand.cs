using MediatR;
using Tumultu.Application.Interfaces.Common;

namespace Tumultu.Application.AnalysisResults.Commands;

public record CreateAnalysisResultCommand : IRequest<Guid>;

public class CreateAnalysisResultCommandHandler : IRequestHandler<CreateAnalysisResultCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateAnalysisResultCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Guid> Handle(CreateAnalysisResultCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}