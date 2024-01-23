using Tumultu.Domain.Common;
using Tumultu.Domain.Entities;

namespace Tumultu.Domain.Events;

public sealed class FileDeletedEvent : BaseEvent
{
    public FileDeletedEvent(FileEntity entity)
    {
        FileEntity = entity;
    }

    public FileEntity FileEntity { get; }
}
