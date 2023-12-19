using MediatR;
using Microsoft.Extensions.Logging;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Behaviours.EventHandlers;

public class BehaviourDeletedEventHandler : INotificationHandler<BehaviourDeletedEvent>
{
    private readonly ILogger<BehaviourDeletedEventHandler> _logger;

    public BehaviourDeletedEventHandler(ILogger<BehaviourDeletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(BehaviourDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Domain event: Behaviour with id: {notification.Behaviour.Id} has been deleted.");
        return Task.CompletedTask;
    }
}