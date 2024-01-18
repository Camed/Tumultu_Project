using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.AnalysisResults.Commands;

public record CreateAnalysisResultCommand : IRequest<Guid>;

public class CreateAnalysisResultCommandHandler : IRequestHandler<CreateAnalysisResultCommand, Guid>
{
    private readonly IAnalysisResultRepository _repository;

    public CreateAnalysisResultCommandHandler(IAnalysisResultRepository repository)
    {
        _repository = repository;
    }

    public Task<Guid> Handle(CreateAnalysisResultCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}