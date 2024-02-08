using Tumultu.Domain.Common;
using Tumultu.Domain.ValueObjects;

namespace Tumultu.Domain.Entities;

public class AnalysisResult : BaseEntity<Guid>
{
    public DateTimeOffset AnalysisDate { get; set; }
    public IEnumerable<Signature> DetectedSignatures { get; set; } = [];
    public IEnumerable<Behaviour> DetectedBehaviours { get; set; } = [];
    public IEnumerable<double> EntropyData { get; set; }
    public User? OriginalAnalysisBy { get; set; }
    public User? LatestAnalysisBy { get; set;}

}
