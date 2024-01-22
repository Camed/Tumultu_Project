﻿using MediatR;
using Tumultu.Application.Common.Interfaces;

namespace Tumultu.Application.Behaviours.Commands;

public record CreateBehaviourCommand : IRequest<int>;

public class CreateBehaviourCommandHandler : IRequestHandler<CreateBehaviourCommand, int>
{

    private readonly IBehaviourRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBehaviourCommandHandler(IBehaviourRepository behaviourRepository, IUnitOfWork unitOfWork)
    {
        _repository = behaviourRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<int> Handle(CreateBehaviourCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}