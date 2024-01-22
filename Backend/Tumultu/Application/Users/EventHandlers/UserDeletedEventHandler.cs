using MediatR;
using Microsoft.Extensions.Logging;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Users.EventHandlers;

public class UserDeletedEventHandler : INotificationHandler<UserDeletedEvent>
{
    private readonly ILogger<UserDeletedEventHandler> _logger;

    public UserDeletedEventHandler(ILogger<UserDeletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(UserDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Domain event: User with id: {notification.User.Id} and username: {notification.User.Username} has been deleted.");
        return Task.CompletedTask;
    }
}