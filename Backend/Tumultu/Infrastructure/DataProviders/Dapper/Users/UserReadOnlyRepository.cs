using System.Data;
using Dapper;
using Tumultu.Application.Users;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.DataProviders.Dapper.Common;

namespace Tumultu.Infrastructure.DataProviders.Dapper.Users;

internal class UserReadOnlyRepository : DapperRepositoryBase, IUserReadOnlyRepository
{
    public UserReadOnlyRepository(IDbConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        using IDbConnection connection = ConnectionFactory.CreateConnection();
        const string sql = "SELECT * FROM User";
        return await connection.QueryAsync<User>(sql);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        using IDbConnection connection = ConnectionFactory.CreateConnection();
        const string sql = """
                           SELECT * FROM User
                           WHERE Id = @id
                           """;
        return await connection.QuerySingleOrDefaultAsync<User?>(sql, new { id });
    }
}