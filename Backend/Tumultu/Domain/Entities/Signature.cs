using Tumultu.Domain.Enums;
using Tumultu.Domain.Common;

namespace Tumultu.Domain.Entities;

public class Signature : BaseEntity<int>
{
    public byte[]? SignatureBytes { get; set; }
    public Endianess SignatureEndianess { get; set; } = Endianess.LittleEndian;
    public string? Name { get; set; }
    public string? Description { get; set; }
}
