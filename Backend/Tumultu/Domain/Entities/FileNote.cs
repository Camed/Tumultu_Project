using Tumultu.Domain.Common;

namespace Tumultu.Domain.Entities;

public class FileNote : BaseEntity<Guid>
{
    public string? Date { get; set; }
    public string? Text { get; set; }
}
