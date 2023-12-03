using Tumultu.Application.Common.Models;
using Tumultu.Domain.Constants;
using Tumultu.Domain.Entities;

namespace Tumultu.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<User?> GetUserById(Guid id);
    Task<bool> IsInRoleAsync(Guid? id, Roles role);
    Task<bool> AuthorizeAsync(Guid? Id, Roles role);
    Task<(Result result, Guid userId)> CreateUserAsync(string userName, string password);
    Task<Result> DeleteUserAsync(Guid userId);

}
