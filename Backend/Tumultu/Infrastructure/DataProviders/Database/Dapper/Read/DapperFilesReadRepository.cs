using System.Data;
using Dapper;
using Tumultu.Application.Files;
using Tumultu.Application.Files.Queries;
using Tumultu.Domain.Entities;

namespace Tumultu.Infrastructure.DataProviders.Database.Dapper.Read;

class DapperFilesReadRepository : IFilesReadRepository
{
    private readonly IDapperDbContext _context;

    public DapperFilesReadRepository(IDapperDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FileEntity>> GetAllAsync()
    {
        using IDbConnection connection = _context.CreateConnection();
        const string sql = "SELECT * FROM FileEnity";
        return await connection.QueryAsync<FileEntity>(sql);
    }

    public async Task<FileEntity?> GetByIdAsync(Guid id)
    {
        using IDbConnection connection = _context.CreateConnection();
        const string sql = """
                           SELECT * FROM FileEnity
                           WHERE Id = @id
                           """;
        return await connection.QuerySingleOrDefaultAsync<FileEntity?>(sql, new { id });
    }

    public async Task<IEnumerable<FileEntity>> GetAllByAnySignature(string? md5Signature, string? sha1Signature, string? sha256Signature)
    {
        using IDbConnection connection = _context.CreateConnection();
        const string sql = """
                           SELECT * FROM FileEnity
                           WHERE md5_signature = @md5Signature 
                           OR sha1_signature = @sha1Signature
                           OR sha256_signature = @sha256Signature
                           """;
        return await connection.QueryAsync<FileEntity>(sql, new {md5Signature, sha1Signature, sha256Signature});
    }
}