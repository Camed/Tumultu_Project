using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Tumultu.Infrastructure.Database.Dapper;

internal class PostgreSqlDbConnectionFactory : IDbConnectionFactory
{
    private readonly IConfiguration _configuration;
    private readonly string? _connectionString;

    public PostgreSqlDbConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("SqlConnection");
    }

    public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
}