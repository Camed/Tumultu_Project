using System.Data;

namespace Tumultu.Infrastructure.DataProviders.Database.Dapper;

public interface IDapperDbContext
{
    IDbConnection CreateConnection();
}