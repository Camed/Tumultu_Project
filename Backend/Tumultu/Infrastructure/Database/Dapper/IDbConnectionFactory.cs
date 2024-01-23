using System.Data;

namespace Tumultu.Infrastructure.Database.Dapper;

internal interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}