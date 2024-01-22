using System.Data;
using Dapper;
using Tumultu.Application.Behaviours;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.Database.Dapper.Repositories.Common;

namespace Tumultu.Infrastructure.Database.Dapper.Repositories.Behaviours;

internal class BehaviourReadOnlyRepository : DapperRepositoryBase, IBehaviourReadOnlyRepository
{
    public BehaviourReadOnlyRepository(IDbConnectionFactory connectionFactory) 
        : base(connectionFactory)
    {
    }

    public async Task<IEnumerable<Behaviour>> GetAllAsync()
    {
        using IDbConnection connection = ConnectionFactory.CreateConnection();
        const string sql = "SELECT * FROM Behaviour";
        return await connection.QueryAsync<Behaviour>(sql);
    }

    public async Task<Behaviour?> GetByIdAsync(int id)
    {
        using IDbConnection connection = ConnectionFactory.CreateConnection();
        const string sql = """
                           SELECT * FROM Behaviour
                           WHERE Id = @id
                           """;
        return await connection.QuerySingleOrDefaultAsync<Behaviour?>(sql, new { id });
    }
}