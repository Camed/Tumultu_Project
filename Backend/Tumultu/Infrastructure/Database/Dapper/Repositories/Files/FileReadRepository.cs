using System.Data;
using Dapper;
using Tumultu.Application.Files;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.Database.Dapper.Repositories.Common;

namespace Tumultu.Infrastructure.Database.Dapper.Repositories.Files;

internal class FileReadRepository : DapperRepositoryBase, IFileReadOnlyRepository
{
    public FileReadRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }

    public async Task<IEnumerable<FileEntity>> GetAllAsync()
    {
        using IDbConnection connection = ConnectionFactory.CreateConnection();
        const string sql = "SELECT * FROM FileEntity";
        return await connection.QueryAsync<FileEntity>(sql);
    }

    public async Task<FileEntity?> GetByIdAsync(Guid id)
    {
        using IDbConnection connection = ConnectionFactory.CreateConnection();
        const string sql = """
                           SELECT * FROM FileEnity
                           WHERE Id = @id
                           """;
        return await connection.QuerySingleOrDefaultAsync<FileEntity?>(sql, new { id });
    }

    public async Task<IEnumerable<FileEntity>> GetAllByAnySignature(string? md5Signature, string? sha1Signature, string? sha256Signature)
    {
        using IDbConnection connection = ConnectionFactory.CreateConnection();
        const string sql = """
                           SELECT * FROM FileEnity
                           WHERE md5_signature = @md5Signature 
                           OR sha1_signature = @sha1Signature
                           OR sha256_signature = @sha256Signature
                           """;
        return await connection.QueryAsync<FileEntity>(sql, new {md5Signature, sha1Signature, sha256Signature});
    }
}