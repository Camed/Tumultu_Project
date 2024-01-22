using System.Data;
using Dapper;
using Tumultu.Application.Files;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.Database.Dapper.Repositories.Common;

namespace Tumultu.Infrastructure.Database.Dapper.Repositories.Files;

internal class FileReadRepository : DapperRepositoryBase<FileEntity, Guid>, IFileReadOnlyRepository
{
    public FileReadRepository(IDbConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    public async Task<IEnumerable<FileEntity>> GetAllByAnySignature(string? md5Signature, string? sha1Signature, string? sha256Signature)
    {
        using IDbConnection connection = ConnectionFactory.CreateConnection();
        var sql = $"""
                   SELECT * FROM "{TableName}"
                   WHERE MD5Signature = @md5Signature
                   OR SHA1Signature = @sha1Signature
                   OR SHA256Signature = @sha256Signature
                   """;
        return await connection.QueryAsync<FileEntity>(sql, new { md5Signature, sha1Signature, sha256Signature });
    }
}