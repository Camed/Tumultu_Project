using Tumultu.Domain.Common;
using Tumultu.Domain.Entities;

namespace Tumultu.Domain.Events;

public sealed class BehaviourDeletedEvent : BaseEvent
{
    public BehaviourDeletedEvent(Behaviour behaviour)
    {
        Behaviour = behaviour;
    }

    public Behaviour Behaviour { get; }
}