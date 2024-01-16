using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Behaviours.Queries;

public record GetBehaviourByIdQuery(int Id) : IRequest<Behaviour>;

public class GetBehaviourByIdQueryHandler : IRequestHandler<GetBehaviourByIdQuery, Behaviour>
{
    private readonly IBehaviourReadRepository _repository;

    public GetBehaviourByIdQueryHandler(IBehaviourReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<Behaviour> Handle(GetBehaviourByIdQuery request, CancellationToken cancellationToken)
    {
        Behaviour? entity = await _repository.GetByIdAsync(request.Id);
        
        Guard.Against.Null(entity);
        return entity;
    }
}