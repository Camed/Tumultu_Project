﻿using Tumultu.Domain.Common;
using Tumultu.Domain.Entities;

namespace Tumultu.Domain.Events;

public sealed class FileVariantCreatedEvent : BaseEvent
{
    public FileVariantCreatedEvent(FileVariant fileVariant)
    {
        FileVariant = fileVariant;
    }
    public FileVariant FileVariant { get; }
}
