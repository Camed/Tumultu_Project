using System.Data;
using Ardalis.GuardClauses;
using Dapper;
using MediatR;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Application.AnalysisResults.Queries;

public record GetAnalysisResultByIdQuery(Guid Id) : IRequest<AnalysisResult>;

public class GetAnalysisResultByIdQueryHandler : IRequestHandler<GetAnalysisResultByIdQuery, AnalysisResult>
{
    private readonly IDBConnectionFactory _connectionFactory;

    public GetAnalysisResultByIdQueryHandler(IDBConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<AnalysisResult> Handle(GetAnalysisResultByIdQuery request, CancellationToken cancellationToken)
    {
        using IDbConnection connection = _connectionFactory.CreateOpenConnection();
        const string sql =
            """
                SELECT ar.Guid, ar.AnalysisDate, ar.EntropyData
                FROM AnalysisResults ar
                WHERE ar.Guid = @Guid
            """;
        AnalysisResult? entity = await connection.QueryFirstOrDefaultAsync(
            sql,
            new { request.Id }
        );

        Guard.Against.Null(entity);
        return entity;
    }
}