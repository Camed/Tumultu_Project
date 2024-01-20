namespace Tumultu.Infrastructure.DataProviders.Dapper.Common;

internal abstract class DapperRepositoryBase
{
    protected IDbConnectionFactory ConnectionFactory { get; }

    protected DapperRepositoryBase(IDbConnectionFactory connectionFactory)
    {
        ConnectionFactory = connectionFactory;
    }
}