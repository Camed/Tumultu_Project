namespace Tumultu.Infrastructure.Database.Dapper.Repositories.Common;

internal abstract class DapperRepositoryBase
{
    protected IDbConnectionFactory ConnectionFactory { get; }

    protected DapperRepositoryBase(IDbConnectionFactory connectionFactory)
    {
        ConnectionFactory = connectionFactory;
    }
}