using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.AnalysisResults.Commands;

public record CreateAnalysisResultCommand : IRequest<Guid>;

public class CreateAnalysisResultCommandHandler : IRequestHandler<CreateAnalysisResultCommand, Guid>
{
    private readonly IAnalysisResultReadRepository _readRepository;
    private readonly IWriteRepository<AnalysisResult, Guid> _writeRepository;

    public CreateAnalysisResultCommandHandler(IAnalysisResultReadRepository readRepository, IWriteRepository<AnalysisResult, Guid>  writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public Task<Guid> Handle(CreateAnalysisResultCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}