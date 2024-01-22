using System.Data;
using Dapper;
using Tumultu.Application.AnalysisResults;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.Database.Dapper.Repositories.Common;

namespace Tumultu.Infrastructure.Database.Dapper.Repositories.AnalysisResults;

internal class AnalysisResultReadOnlyRepository : DapperRepositoryBase, IAnalysisResultReadOnlyRepository
{
    public AnalysisResultReadOnlyRepository(IDbConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }
    
    public async Task<IEnumerable<AnalysisResult>> GetAllAsync()
    {
        using IDbConnection connection = ConnectionFactory.CreateConnection();
        const string sql = "SELECT * FROM AnalysisResult";
        return await connection.QueryAsync<AnalysisResult>(sql);
    }

    public async Task<AnalysisResult?> GetByIdAsync(Guid id)
    {
        using IDbConnection connection = ConnectionFactory.CreateConnection();
        const string sql = """
                           SELECT * FROM AnalysisResult
                           WHERE Id = @id
                           """;
        return await connection.QuerySingleOrDefaultAsync<AnalysisResult?>(sql, new { id });
    }
}
