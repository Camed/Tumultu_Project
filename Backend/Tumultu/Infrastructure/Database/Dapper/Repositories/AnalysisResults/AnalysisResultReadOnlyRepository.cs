using Tumultu.Application.AnalysisResults;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.Database.Dapper.Repositories.Common;

namespace Tumultu.Infrastructure.Database.Dapper.Repositories.AnalysisResults;

internal class AnalysisResultReadOnlyRepository : DapperRepositoryBase<AnalysisResult,Guid>, IAnalysisResultReadOnlyRepository
{
    public AnalysisResultReadOnlyRepository(IDbConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }
}
