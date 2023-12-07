using Tumultu.Domain.Common;

namespace Tumultu.Domain.Entities;

public class AnalysisResult : BaseEntity<Guid>
{
    public DateTimeOffset AnalysisDate { get; set; }
    public IEnumerable<int>? DetectedSignatures { get; set; }
    public IEnumerable<int>? DetectedBehaviours { get; set; }
    public byte[]? EntropyData { get; set; }
    public User? OriginalAnalysisBy { get; set; }
    public User? LatestAnalysisBy { get; set;}

}
