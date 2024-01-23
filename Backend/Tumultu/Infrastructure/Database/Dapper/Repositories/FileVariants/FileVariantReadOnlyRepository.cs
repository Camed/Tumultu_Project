using System.Data;
using Dapper;
using Tumultu.Application.FileVariants;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.Database.Dapper.Repositories.Common;

namespace Tumultu.Infrastructure.Database.Dapper.Repositories.FileVariants;

internal class FileVariantReadOnlyRepository : DapperRepositoryBase<FileVariant, Guid>, IFileVariantReadOnlyRepository
{
    public FileVariantReadOnlyRepository(IDbConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    public async Task<IEnumerable<FileVariant>> GetAllFileVariantsByFile(FileEntity file)
    {
        using IDbConnection connection = ConnectionFactory.CreateConnection();
        var sql = $"""
                   SELECT * FROM "{TableName}"
                   WHERE "FileId" = @FileId;
                   """;
        return await connection.QueryAsync<FileVariant>(sql, new { FileId = file.Id });
    }
}