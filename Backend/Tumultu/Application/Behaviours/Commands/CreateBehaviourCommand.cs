﻿using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Behaviours.Commands;

public record CreateBehaviourCommand : IRequest<int>;

public class CreateBehaviourCommandHandler : IRequestHandler<CreateBehaviourCommand, int>
{

    private readonly IBehaviourRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBehaviourCommandHandler(IBehaviourRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public Task<int> Handle(CreateBehaviourCommand request, CancellationToken cancellationToken)
    {
        // temp stuff for tests
        Behaviour behaviour = new Behaviour();
        throw new NotImplementedException();
    }
}