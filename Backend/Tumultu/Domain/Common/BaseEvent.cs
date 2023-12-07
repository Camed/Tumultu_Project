using MediatR;
namespace Tumultu.Domain.Common;

/// <summary>
/// Base event class, used mainly to contain DomainEvents
/// </summary>
public abstract class BaseEvent : INotification
{
}
