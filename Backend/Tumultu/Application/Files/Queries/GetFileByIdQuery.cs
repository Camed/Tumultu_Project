using Ardalis.GuardClauses;
using Dapper;
using MediatR;
using System.Data;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Files.Queries;

public record GetFileByIdQuery : IRequest<FileEntity>
{
    public Guid Guid { get; init; }
}

public class GetFileByIdQueryHandler : IRequestHandler<GetFileByIdQuery, FileEntity>
{
    private readonly IDBConnectionFactory _connectionFactory;
    public GetFileByIdQueryHandler(IDBConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<FileEntity> Handle(GetFileByIdQuery request, CancellationToken cancellationToken)
    {
       using IDbConnection connection = _connectionFactory.CreateOpenConnection();
       const string sql =
            """
                SELECT f.Guid, f.Size, f.MD5Signature, f.SHA1Signature, f.SHA256Signature
                FROM Files f
                WHERE f.Guid = @Guid
            """;
       FileEntity? entity = await connection.QueryFirstOrDefaultAsync(
                 sql,
                 new { request.Guid }
            );

        Guard.Against.Null(entity);
        return entity;
    }
}
