using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.AnalysisResults.Queries;

public record GetAnalysisResultByIdQuery(Guid Id) : IRequest<AnalysisResult>;

public class GetAnalysisResultByIdQueryHandler : IRequestHandler<GetAnalysisResultByIdQuery, AnalysisResult>
{
    private readonly IAnalysisResultReadOnlyRepository _repository;

    public GetAnalysisResultByIdQueryHandler(IAnalysisResultReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<AnalysisResult> Handle(GetAnalysisResultByIdQuery request, CancellationToken cancellationToken)
    {
        AnalysisResult? analysisResult = await _repository.GetByIdAsync(request.Id);

        Guard.Against.Null(analysisResult);
        return analysisResult;
    }
}