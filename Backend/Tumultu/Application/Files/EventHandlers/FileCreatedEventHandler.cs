    using MediatR;
using Microsoft.Extensions.Logging;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Files.EventHandlers;

public class FileCreatedEventHandler : INotificationHandler<FileCreatedEvent>
{
    private readonly ILogger<FileCreatedEventHandler> _logger;

    public FileCreatedEventHandler(ILogger<FileCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(FileCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Domain event: File with id: {notification.FileEntity.Id} has been created.");
        return Task.CompletedTask;
    }
}
