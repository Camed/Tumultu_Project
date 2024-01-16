using MediatR;
using Microsoft.Extensions.Logging;
using Tumultu.Domain.Events;

namespace Tumultu.Application.FileVariants.EventHandlers;

public class FileVariantDeletedEventHandler : INotificationHandler<FileVariantDeletedEvent>
{
    private readonly ILogger<FileVariantDeletedEventHandler> _logger;
    public FileVariantDeletedEventHandler(ILogger<FileVariantDeletedEventHandler> logger)
    {
        _logger = logger; 
    }
    public Task Handle(FileVariantDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Domain event: File variant '{notification.FileVariant.Id}' has been deleted");
        return Task.CompletedTask;
    }
}
