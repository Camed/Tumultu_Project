using System.Data;
using Dapper;
using Tumultu.Application.Users;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.Database.Dapper.Repositories.Common;

namespace Tumultu.Infrastructure.Database.Dapper.Repositories.Users;

internal class UserReadOnlyRepository : DapperRepositoryBase<User, Guid>, IUserReadOnlyRepository
{
    public UserReadOnlyRepository(IDbConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        using IDbConnection connection = ConnectionFactory.CreateConnection();
        var sql = $"""
                   SELECT * FROM "{TableName}"
                   WHERE Username = @username
                   """;
        return await connection.QuerySingleOrDefaultAsync<User?>(sql, new { username });
    }
}