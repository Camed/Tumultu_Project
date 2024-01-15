using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.AnalysisResults.Commands;

public record DeleteAnalysisResultCommand(Guid Id) : IRequest;

public class DeleteAnalysisResultCommandHandler : IRequestHandler<DeleteAnalysisResultCommand>
{
    private readonly IAnalysisResultReadRepository _readRepository;
    private readonly IWriteRepository<AnalysisResult, Guid> _writeRepository;

    public DeleteAnalysisResultCommandHandler(IAnalysisResultReadRepository readRepository, IWriteRepository<AnalysisResult, Guid>  writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task Handle(DeleteAnalysisResultCommand request, CancellationToken token)
    {
        AnalysisResult? entity = await _readRepository.GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        _writeRepository.Delete(entity);

        entity.AddDomainEvent(new AnalysisDeletedEvent(entity));

        await _writeRepository.SaveChangesAsync(token);
    }
}