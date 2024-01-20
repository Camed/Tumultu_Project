using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Users.Queries;

public record GetUserByUsernameQuery : IRequest<User>
{
    public string Username { get; init; }
}

public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUsernameQuery, User>
{
    private readonly IUserReadOnlyRepository _repository;

    public GetUserByUserNameQueryHandler(IUserReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<User> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
    {
        User? user = await _repository.GetByUsernameAsync(request.Username);

        Guard.Against.Null(user);

        return user;
    }
}