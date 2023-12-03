namespace Tumultu.Domain.Common;

/// <summary>
/// Base auditable entity, extension of BaseEntity class with some additional fields.
/// </summary>
/// <typeparam name="T">Primary key type for given entity.</typeparam>
public abstract class BaseAuditableEntity<T> : BaseEntity<T>
{
    public DateTimeOffset CreationTime { get; set; }
    public DateTimeOffset ModifiedTime { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    
}
