using MediatR;
using Microsoft.Extensions.Logging;
using Tumultu.Domain.Events;

namespace Tumultu.Application.FileVariants.EventHandlers;

public class FileVariantCreatedEventHandler : INotificationHandler<FileVariantCreatedEvent>
{
    private readonly ILogger<FileVariantCreatedEventHandler> _logger;

    public FileVariantCreatedEventHandler(ILogger<FileVariantCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(FileVariantCreatedEvent notification, CancellationToken token)
    {
        _logger.LogInformation($"Domain event: FileVariant with id: {notification.FileVariant.Id} has been created.");
        return Task.CompletedTask;
    }
}
