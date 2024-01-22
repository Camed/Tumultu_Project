using MediatR;
using Microsoft.Extensions.Logging;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Users.EventHandlers;

public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
{
    private readonly ILogger<UserCreatedEventHandler> _logger;

    public UserCreatedEventHandler(ILogger<UserCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Domain event: User with id: {notification.User.Id} and username: {notification.User.Username} has been created.");
        return Task.CompletedTask;
    }
}
