using Tumultu.Domain.Common;
using Tumultu.Domain.Entities;

namespace Tumultu.Domain.Events;

public class UserCreatedEvent : BaseEvent
{
    public UserCreatedEvent(User user)
    {
        User = user;
    }

    public User User { get; }
}