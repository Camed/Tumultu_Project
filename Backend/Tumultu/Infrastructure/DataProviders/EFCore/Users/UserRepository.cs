using Tumultu.Application.Users;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.DataProviders.EFCore.Common;

namespace Tumultu.Infrastructure.DataProviders.EFCore.Users;

internal class UserRepository : EfCoreRepositoryBase<User, Guid>, IUserRepository
{
    public UserRepository(EfCoreDbContext context) : base(context)
    {
    }
}