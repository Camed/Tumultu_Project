﻿using Tumultu.Domain.Common;
using Tumultu.Domain.Entities;

namespace Tumultu.Domain.Events;
public sealed class FileVariantDeletedEvent : BaseEvent
{
    public FileVariantDeletedEvent(FileVariant fileVariant)
    {
        FileVariant = fileVariant;
    }

    public FileVariant FileVariant { get; }
}
