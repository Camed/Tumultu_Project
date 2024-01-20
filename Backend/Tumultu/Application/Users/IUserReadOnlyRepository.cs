using Tumultu.Application.Common.Interfaces;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Users;

public interface IUserReadOnlyRepository : IReadOnlyRepository<User, Guid>
{
    Task<User?> GetByUsernameAsync(string username);
}
