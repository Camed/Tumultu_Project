using MediatR;
using Microsoft.Extensions.Logging;
using Tumultu.Domain.Events;

namespace Tumultu.Application.AnalysisResults.EventHandlers;

public class AnalysisResultCreatedEventHandler : INotificationHandler<AnalysisCreatedEvent>
{
    private readonly ILogger<AnalysisResultCreatedEventHandler> _logger;

    public AnalysisResultCreatedEventHandler(ILogger<AnalysisResultCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(AnalysisCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Domain event: Analysis with id: {notification.Analysis.Id} has been created.");
        return Task.CompletedTask;
    }
}