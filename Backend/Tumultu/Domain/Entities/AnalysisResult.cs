using Tumultu.Domain.Common;
using Tumultu.Domain.Constants;
using Tumultu.Domain.Extensions;
using Tumultu.Domain.ValueObjects;

namespace Tumultu.Domain.Entities;

public class AnalysisResult : BaseEntity<Guid>
{
    private AnalysisResult(byte[] payload, User requestingUser)
    {
        this.AnalysisDate = DateTime.UtcNow;
        this.LatestAnalysisBy = requestingUser;
        this.DetectedSignatures = Signatures.MatchSignatures(payload);
        this.OriginalAnalysisBy = requestingUser;
    }
    public DateTimeOffset AnalysisDate { get; set; }
    public IList<Signature> DetectedSignatures { get; set; } = [];
    public IList<Behaviour> DetectedBehaviours { get; set; } = [];
    public IList<double> EntropyData { get; set; } = [];
    public User? OriginalAnalysisBy { get; set; }
    public User? LatestAnalysisBy { get; set;}

    public static AnalysisResult CreateAnalysis(byte[] payload, User requestingUser)
    {
        var analysisResult = new AnalysisResult(payload, requestingUser);
        analysisResult.EntropyData =  payload.CalculateEntropy(256);

        return analysisResult;
    }

    public static async Task<AnalysisResult> CreateAnalysisAsync(byte[] payload, User requestingUser, CancellationToken cancellationToken)
    {
        var analysisResult = new AnalysisResult(payload, requestingUser);
        analysisResult.EntropyData = await payload.CalculateEntropyAsync(256, cancellationToken);

        return analysisResult;
    }
}
