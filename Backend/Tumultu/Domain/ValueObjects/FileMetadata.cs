using Tumultu.Domain.Common;

namespace Tumultu.Domain.ValueObjects;

public class FileMetadata : ValueObject
{
    public FileMetadata() { }
    public FileMetadata(string? author, string? description, string? version)
    {
            Author = author;
            Description = description;
            Version = version;
        }

    public string? Author { get; set; }
    public string? Description { get; set; }
    public string? Version { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
            yield return Author!;
            yield return Description!;
            yield return Version!;
        }
}