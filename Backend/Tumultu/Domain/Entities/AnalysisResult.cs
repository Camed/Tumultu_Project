using Tumultu.Domain.Common;
using Tumultu.Domain.Constants;
using Tumultu.Domain.Extensions;
using Tumultu.Domain.ValueObjects;

namespace Tumultu.Domain.Entities;

public class AnalysisResult : BaseEntity<Guid>
{
    public DateTimeOffset AnalysisDate { get; set; }
    public IList<Signature> DetectedSignatures { get; set; } = [];
    public IList<Behaviour> DetectedBehaviours { get; set; } = [];
    public IList<double> EntropyData { get; set; } = [];
    public User? OriginalAnalysisBy { get; set; }
    public User? LatestAnalysisBy { get; set;}

    public static AnalysisResult CreateAnalysis(FileEntity file)
    {
        throw new NotImplementedException();
    }

    public static async Task<AnalysisResult> CreateAnalysisAsync(byte[] payload, User requestingUser)
    {
        var analysisResult = new AnalysisResult();

        analysisResult.AnalysisDate = DateTime.UtcNow;
        analysisResult.LatestAnalysisBy = requestingUser;
        analysisResult.DetectedSignatures = Signatures.MatchSignatures(payload);
        analysisResult.EntropyData = await payload.CalculateEntropyAsync(256);
        analysisResult.OriginalAnalysisBy = requestingUser;

        return analysisResult;
    }


}
