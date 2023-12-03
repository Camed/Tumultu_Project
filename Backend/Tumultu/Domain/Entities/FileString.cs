using Tumultu.Domain.Common;

namespace Tumultu.Domain.Entities;

public class FileString : BaseEntity<Guid>
{
    public int? OffsetInFile { get; set; }
    public int? StringType { get; set; }
    public string? StringValue { get; set; }
}
