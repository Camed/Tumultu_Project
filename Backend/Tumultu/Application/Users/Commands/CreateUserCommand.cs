using MediatR;
using Tumultu.Application.Common.Exceptions;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Users.Commands;

public record CreateUserCommand : IRequest<Guid>
{
    public string Username { get; init; }
    public string Password { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string Email { get; init; }
};

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CreateUserCommandHandler(IUserRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        User? existingUser = await _repository.GetByUsernameAsync(request.Username);
        
        if (existingUser is not null)
        {
            // I am not sure if this is right, to re-evaluate later
            throw new UserAlreadyExistsException(request.Username);
        }

        var user = new User
        {
            Username = request.Username,
            FirstName = request.FirstName,
            LastName = request.LastName,
            
            // needs to be hashed
            PasswordHash = request.Password,
            PasswordSalt = "",
            
            Email = request.Email,
            RegistrationDate = DateTimeOffset.UtcNow
        };

        _repository.Insert(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        user.AddDomainEvent(new UserCreatedEvent(user));

        return user.Id;
    }
}