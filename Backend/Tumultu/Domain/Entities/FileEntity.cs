using Tumultu.Domain.Common;
using Tumultu.Domain.ValueObjects;

namespace Tumultu.Domain.Entities;

public class FileEntity : BaseEntity<Guid>
{
    public IEnumerable<FileVariant>? Variants { get; set; }
    public IEnumerable<FileString>? FileStrings { get; set; }
    public int Size { get; set; } = -1;
    public string? MD5Signature { get; set; }
    public string? SHA1Signature { get; set; }
    public string? SHA256Signature { get; set; }
    public AnalysisResult? AnalysisResult { get; set; }
}
