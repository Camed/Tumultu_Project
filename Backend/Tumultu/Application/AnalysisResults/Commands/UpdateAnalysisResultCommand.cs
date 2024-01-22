using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.AnalysisResults.Commands;

public record UpdateAnalysisResultCommand(Guid Id) : IRequest;

public class UpdateAnalysisResultCommandHandler : IRequestHandler<UpdateAnalysisResultCommand>
{
    private readonly IAnalysisResultRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAnalysisResultCommandHandler(IAnalysisResultRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateAnalysisResultCommand request, CancellationToken cancellationToken)
    {
        AnalysisResult? entity = await _repository.GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        // change anything in entity
        
        _repository.Update(entity);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}