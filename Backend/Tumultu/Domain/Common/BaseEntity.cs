using System.ComponentModel.DataAnnotations.Schema;

namespace Tumultu.Domain.Common;
/// <summary>
/// Base entity, every entity in the project should somehow (directly on indirectly) derive from it.
/// </summary>
/// <typeparam name="T">Type of the primary key for the entity</typeparam>
public abstract class BaseEntity<T>
{
    // warning disabled - reason: Id cannot ever be null
#pragma warning disable CS8618
    public T Id { get; set; }
#pragma warning restore CS8618

    private readonly List<BaseEvent> _events = [];

    [NotMapped]
    public IReadOnlyCollection<BaseEvent> DomainEvents => _events.AsReadOnly();

    public void AddDomainEvent(BaseEvent domainEvent) => _events.Add(domainEvent);
    public void RemoveDomainEvent(BaseEvent domainEvent) => _events.Remove(domainEvent);
    public void ClearDomainEvents() => _events.Clear();
}
