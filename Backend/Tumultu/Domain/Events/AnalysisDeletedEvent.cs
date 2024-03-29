﻿using Tumultu.Domain.Common;
using Tumultu.Domain.Entities;

namespace Tumultu.Domain.Events;

public sealed class AnalysisDeletedEvent : BaseEvent
{
    public AnalysisDeletedEvent(AnalysisResult analysis)
    {
        Analysis = analysis;
    }

    public AnalysisResult Analysis { get; }
}
