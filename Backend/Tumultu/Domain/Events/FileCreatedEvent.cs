using Tumultu.Domain.Common;
using Tumultu.Domain.Entities;

namespace Tumultu.Domain.Events;

public class FileCreatedEvent : BaseEvent
{
    public FileCreatedEvent(FileEntity entity)
    {
        FileEntity = entity;
    }

    public FileEntity FileEntity { get; }
}
