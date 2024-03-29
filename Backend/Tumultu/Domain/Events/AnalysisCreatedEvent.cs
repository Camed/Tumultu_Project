﻿using Tumultu.Domain.Common;
using Tumultu.Domain.Entities;

namespace Tumultu.Domain.Events;

public sealed class AnalysisCreatedEvent : BaseEvent
{
    public AnalysisCreatedEvent(AnalysisResult analysis)
    {
        Analysis = analysis;
    }

    public AnalysisResult Analysis { get; }
}
