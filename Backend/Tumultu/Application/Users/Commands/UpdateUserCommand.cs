using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Users.Commands;

public record UpdateUserCommand : IRequest
{
    public Guid Id { get; init; }
}

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IUserRepository _repository;

    public UpdateUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        User? entity = await _repository.GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        // change anything in entity

        _repository.Update(entity);

        await _repository.SaveChangesAsync(cancellationToken);
    }
}