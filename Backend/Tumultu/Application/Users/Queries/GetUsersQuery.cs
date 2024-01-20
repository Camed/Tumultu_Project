using MediatR;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Users.Queries;

public record GetUsersQuery : IRequest<IEnumerable<User>>;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
{
    private readonly IUserReadOnlyRepository _repository;

    public GetUsersQueryHandler(IUserReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}