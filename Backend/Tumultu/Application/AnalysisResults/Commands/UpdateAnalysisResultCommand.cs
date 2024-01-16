using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.AnalysisResults.Commands;

public record UpdateAnalysisResultCommand(Guid Id) : IRequest;

public class UpdateAnalysisResultCommandHandler : IRequestHandler<UpdateAnalysisResultCommand>
{
    private readonly IAnalysisResultReadRepository _readRepository;
    private readonly IWriteRepository<AnalysisResult, Guid> _writeRepository;

    public UpdateAnalysisResultCommandHandler(IAnalysisResultReadRepository readRepository, IWriteRepository<AnalysisResult, Guid>  writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task Handle(UpdateAnalysisResultCommand request, CancellationToken cancellationToken)
    {
        AnalysisResult? entity = await _readRepository.GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        // change anything in entity
        
        _writeRepository.Update(entity);
        await _writeRepository.SaveChangesAsync(cancellationToken);
    }
}