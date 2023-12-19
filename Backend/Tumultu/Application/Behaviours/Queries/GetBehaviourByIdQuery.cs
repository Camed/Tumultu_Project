using Ardalis.GuardClauses;
using Dapper;
using MediatR;
using System.Data;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Behaviours.Queries;

public record GetBehaviourByIdQuery(int Id) : IRequest<Behaviour>;

public class GetBehaviourByIdQueryHandler : IRequestHandler<GetBehaviourByIdQuery, Behaviour>
{
    private readonly IDBConnectionFactory _connectionFactory;

    public GetBehaviourByIdQueryHandler(IDBConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<Behaviour> Handle(GetBehaviourByIdQuery request, CancellationToken cancellationToken)
    {
        using IDbConnection connection = _connectionFactory.CreateOpenConnection();
        const string sql =
            """
                SELECT b.Id, b.NetworkActivity, b.FileSystemInteraction
                FROM Behaviours b
                WHERE b.Id = @Id
            """;
        Behaviour? entity = await connection.QueryFirstOrDefaultAsync(
            sql,
            new { request.Id }
        );

        Guard.Against.Null(entity);
        return entity;
    }
}