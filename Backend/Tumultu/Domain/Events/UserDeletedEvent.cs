using Tumultu.Domain.Common;
using Tumultu.Domain.Entities;

namespace Tumultu.Domain.Events
{
    public class UserDeletedEvent : BaseEvent
    {
        public UserDeletedEvent(User user)
        {
            User = user;
        }

        public User User { get; }
    }
}