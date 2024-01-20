using Ardalis.GuardClauses;
using MediatR;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Users.Commands;

public record DeleteUserCommand(Guid Id) : IRequest;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepository _repository;

    public DeleteUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        User? entity = await _repository.GetByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, entity);

        _repository.Delete(entity);

        await _repository.SaveChangesAsync(cancellationToken);

        entity.AddDomainEvent(new UserDeletedEvent(entity));
    }
}