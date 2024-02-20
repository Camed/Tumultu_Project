using Tumultu.Domain.ValueObjects;
using Tumultu.Domain.Common;


namespace Tumultu.Domain.Entities;

public class FileVariant : BaseAuditableEntity<Guid>
{
    public FileEntity? File { get; set; }
    public string? Name { get; set; }
    public User? UploadedBy { get; set; }
    public IList<Tag> Tags { get; set; } = [];
    public FileMetadata? Metadata { get; set; }

    public static FileVariant CreateFileVariant(FileEntity file, User requestingUser)
    {
        // create logic for file variant creation and gathering data from payload

        var variant = new FileVariant()
        {
            File = file,
            UploadedBy = requestingUser,
            CreationTime = DateTime.UtcNow,
            ModifiedTime = DateTime.UtcNow
        };
        return variant;
    }

    public static Task<FileVariant> CreateFileVariantAsync(FileEntity file, User requestingUser)
    {
        // create logic for file variant creation and gathering data from payload
        throw new NotImplementedException();
    }
}