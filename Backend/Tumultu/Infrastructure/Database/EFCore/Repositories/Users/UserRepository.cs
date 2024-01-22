using Tumultu.Application.Users;
using Tumultu.Domain.Entities;
using Tumultu.Infrastructure.Database.EFCore.Repositories.Common;

namespace Tumultu.Infrastructure.Database.EFCore.Repositories.Users;

internal class UserRepository : EfCoreRepositoryBase<User, Guid>, IUserRepository
{
    public UserRepository(EfCoreDbContext context) : base(context)
    {
    }
}