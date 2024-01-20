using System.Data;

namespace Tumultu.Infrastructure.DataProviders.Dapper;

internal interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}