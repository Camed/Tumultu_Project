using System.Data;

namespace Tumultu.Application.Common.Interfaces;
public interface IDBConnectionFactory
{
    IDbConnection CreateOpenConnection();
}
