using System.Data;
using Dapper;
using Tumultu.Application.FileVariants;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.Database.Dapper.Repositories.Common;

namespace Tumultu.Infrastructure.Database.Dapper.Repositories.FileVariants;

internal class FileVariantReadOnlyRepository : DapperRepositoryBase, IFileVariantReadOnlyRepository
{
    public FileVariantReadOnlyRepository(IDbConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }

    public async Task<IEnumerable<FileVariant>> GetAllAsync()
    {
        using IDbConnection connection = ConnectionFactory.CreateConnection();
        const string sql = "SELECT * FROM FileVariant";
        return await connection.QueryAsync<FileVariant>(sql);
    }

    public async Task<FileVariant?> GetByIdAsync(Guid id)
    {
        using IDbConnection connection = ConnectionFactory.CreateConnection();
        const string sql = """
                           SELECT * FROM FileVariant
                           WHERE Id = @id
                           """;
        return await connection.QuerySingleOrDefaultAsync<FileVariant?>(sql, new { id });
    }

    public async Task<IEnumerable<FileVariant>> GetAllFileVariantsByFile(FileEntity file)
    {
        using IDbConnection connection = ConnectionFactory.CreateConnection();
        const string sql = """
                           SELECT * FROM FileVariant
                           WHERE FileId = @FileId;
                           """;
        return await connection.QueryAsync<FileVariant>(sql, new { FileId = file.Id });
    }
}