using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.AnalysisResults.Commands;

public record DeleteAnalysisResultCommand(Guid Id) : IRequest;

public class DeleteAnalysisResultCommandHandler : IRequestHandler<DeleteAnalysisResultCommand>
{
    private readonly IAnalysisResultRepository _repository;

    public DeleteAnalysisResultCommandHandler(IAnalysisResultRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteAnalysisResultCommand request, CancellationToken token)
    {
        AnalysisResult? entity = await _repository.GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        _repository.Delete(entity);

        entity.AddDomainEvent(new AnalysisDeletedEvent(entity));

        await _repository.SaveChangesAsync(token);
    }
}