using Tumultu.Domain.Common;
using Tumultu.Domain.Enums;

namespace Tumultu.Domain.ValueObjects;

public class Signature : ValueObject
{
    public Signature() {}
    public Signature(byte[]? bytes, int offset, string? name, string description, string[] possibleExtensions, Endianess endianess = Endianess.LittleEndian)
    {
        this.FileExtensions = possibleExtensions;
        this.Description = description;
        this.Offset = offset;
        this.SignatureEndianess = endianess;
        this.Name = name;
        this.SignatureBytes = bytes;
    }
    public byte[]? SignatureBytes { get; set; }
    public int? Offset { get; set; }
    public string[] FileExtensions { get; set; }
    public Endianess SignatureEndianess { get; set; } = Endianess.LittleEndian;
    public string? Name { get; set; }
    public string? Description { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return SignatureBytes!;
        yield return SignatureEndianess;
        yield return Name!;
        yield return Description!;
        yield return Offset!;
        yield return FileExtensions;
    }
}
