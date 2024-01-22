using System.Data;
using Dapper;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Common;

namespace Tumultu.Infrastructure.Database.Dapper.Repositories.Common;

internal abstract class DapperRepositoryBase<TEntity,TId> : IReadOnlyRepository<TEntity, TId> where TEntity : BaseEntity<TId>
{
    
    protected static readonly string TableName = typeof(TEntity).Name;
    
    protected IDbConnectionFactory ConnectionFactory { get; }

    protected DapperRepositoryBase(IDbConnectionFactory connectionFactory)
    {
        ConnectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        using IDbConnection connection = ConnectionFactory.CreateConnection();
        var sql = $"""
                   SELECT * FROM "{TableName}"
                   """;
        return await connection.QueryAsync<TEntity>(sql);
    }

    public async Task<TEntity?> GetByIdAsync(TId id)
    {
        using IDbConnection connection = ConnectionFactory.CreateConnection();
        var sql = $"""
                   SELECT * FROM "{TableName}"
                   WHERE Id = @id
                   """;
        return await connection.QuerySingleOrDefaultAsync<TEntity?>(sql, new { id });
    }
}