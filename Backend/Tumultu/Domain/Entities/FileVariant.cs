using Tumultu.Domain.ValueObjects;
using Tumultu.Domain.Common;


namespace Tumultu.Domain.Entities;

public class FileVariant : BaseAuditableEntity<Guid>
{
    public FileEntity? File { get; set; }
    public string? Name { get; set; }
    public User? UploadedBy { get; set; }
    public IEnumerable<Tag> Tags { get; set; } = [];
    public FileMetadata? Metadata { get; set; }
}