using Tumultu.Application.Users;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.Database.Dapper.Repositories.Common;

namespace Tumultu.Infrastructure.Database.Dapper.Repositories.Users;

internal class UserReadOnlyRepository : DapperRepositoryBase<User, Guid>, IUserReadOnlyRepository
{
    public UserReadOnlyRepository(IDbConnectionFactory connectionFactory)
        : base(connectionFactory)
    {
    }
}