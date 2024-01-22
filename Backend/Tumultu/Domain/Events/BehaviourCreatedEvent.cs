using Tumultu.Domain.Common;
using Tumultu.Domain.Entities;

namespace Tumultu.Domain.Events;

public sealed class BehaviourCreatedEvent : BaseEvent
{
    public BehaviourCreatedEvent(Behaviour behaviour)
    {
        Behaviour = behaviour;
    }

    public Behaviour Behaviour { get; }
}