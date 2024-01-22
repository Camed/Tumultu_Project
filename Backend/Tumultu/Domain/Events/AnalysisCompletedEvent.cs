using Tumultu.Domain.Common;
using Tumultu.Domain.Entities;

namespace Tumultu.Domain.Events;

public sealed class AnalysisCompletedEvent : BaseEvent
{
    public AnalysisCompletedEvent(AnalysisResult analysis)
    {
        Analysis = analysis;
    }

    public AnalysisResult Analysis { get; }
}
