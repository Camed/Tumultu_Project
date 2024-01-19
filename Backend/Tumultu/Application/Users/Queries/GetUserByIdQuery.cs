using Ardalis.GuardClauses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumultu.Application.Common.Interfaces;
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
