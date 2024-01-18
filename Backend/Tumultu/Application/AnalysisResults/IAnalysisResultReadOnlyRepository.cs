using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.AnalysisResults;

public interface IAnalysisResultReadOnlyRepository : IReadOnlyRepository<AnalysisResult, Guid>
{
}