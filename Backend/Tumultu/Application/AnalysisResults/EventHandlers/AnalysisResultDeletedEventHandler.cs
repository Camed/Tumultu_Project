using MediatR;
using Microsoft.Extensions.Logging;
using Tumultu.Domain.Events;

namespace Tumultu.Application.AnalysisResults.EventHandlers;

public class AnalysisResultDeletedEventHandler : INotificationHandler<AnalysisDeletedEvent>
{
    private readonly ILogger<AnalysisResultDeletedEventHandler> _logger;

    public AnalysisResultDeletedEventHandler(ILogger<AnalysisResultDeletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(AnalysisDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Domain event: File with id: {notification.Analysis.Id} has been deleted.");
        return Task.CompletedTask;
    }
}