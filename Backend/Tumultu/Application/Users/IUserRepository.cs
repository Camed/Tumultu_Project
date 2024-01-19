using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Users;

public interface IUserRepository : IUserReadOnlyRepository, IWriteRepository<User, Guid>
{
}
