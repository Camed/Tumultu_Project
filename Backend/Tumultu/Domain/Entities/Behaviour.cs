using Tumultu.Domain.Common;

namespace Tumultu.Domain.Entities;

public class Behaviour : BaseEntity<int>
{
    public byte[]? NetworkActivity { get; set; }
    public byte[]? FileSystemInteraction { get; set; }
}
