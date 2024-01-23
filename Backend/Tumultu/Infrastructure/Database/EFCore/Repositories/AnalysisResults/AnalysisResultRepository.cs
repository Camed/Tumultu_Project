using Tumultu.Application.AnalysisResults;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.Database.EFCore.Repositories.Common;

namespace Tumultu.Infrastructure.Database.EFCore.Repositories.AnalysisResults;

internal class AnalysisResultRepository : EfCoreRepositoryBase<AnalysisResult, Guid>, IAnalysisResultRepository
{
    public AnalysisResultRepository(EfCoreDbContext context) : base(context)
    {
    }
}