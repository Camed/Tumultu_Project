using MediatR;
using Microsoft.Extensions.Logging;
using Tumultu.Domain.Events;

namespace Tumultu.Application.Files.EventHandlers
{
    public class FileDeletedEventHandler : INotificationHandler<FileDeletedEvent>
    {
        private readonly ILogger<FileDeletedEventHandler> _logger;
        public FileDeletedEventHandler(ILogger<FileDeletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(FileDeletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Domain event: File '{notification.FileEntity.Id}' has been deleted");
            return Task.CompletedTask;
        }
    }
}
