using MediatR;
using Microsoft.Extensions.Logging;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Behaviours.EventHandlers;

public class BehaviourCreatedEventHandler : INotificationHandler<BehaviourCreatedEvent>
{
    private readonly ILogger<BehaviourCreatedEventHandler> _logger;

    public BehaviourCreatedEventHandler(ILogger<BehaviourCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(BehaviourCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Domain event: Behaviour with id: {notification.Behaviour.Id} has been created.");
        return Task.CompletedTask;
    }
}