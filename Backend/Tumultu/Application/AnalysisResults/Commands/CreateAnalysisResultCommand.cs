﻿using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.AnalysisResults.Commands;

public record CreateAnalysisResultCommand : IRequest<Guid>;

public class CreateAnalysisResultCommandHandler : IRequestHandler<CreateAnalysisResultCommand, Guid>
{
    private readonly IAnalysisResultRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAnalysisResultCommandHandler(IAnalysisResultRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public Task<Guid> Handle(CreateAnalysisResultCommand request, CancellationToken cancellationToken)
    {
        // temporary stuff so tests pass
        //AnalysisResult result = new AnalysisResult();
        throw new NotImplementedException();
    }
}