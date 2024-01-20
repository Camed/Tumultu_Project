using Tumultu.Application.AnalysisResults;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.DataProviders.EFCore.Common;

namespace Tumultu.Infrastructure.DataProviders.EFCore.AnalysisResults;

internal class AnalysisResultRepository : EfCoreRepositoryBase<AnalysisResult, Guid>, IAnalysisResultRepository
{
    public AnalysisResultRepository(EfCoreDbContext context) : base(context)
    {
    }
}