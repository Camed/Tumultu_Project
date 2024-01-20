using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Users.Queries;

public record GetUserByIdQuery : IRequest<User>
{
    public Guid Id { get; init; }
}

public class GetFileByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
{
    private readonly IUserReadOnlyRepository _repository;

    public GetFileByIdQueryHandler(IUserReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        User? user = await _repository.GetByIdAsync(request.Id);

        Guard.Against.Null(user);

        return user;
    }
}
