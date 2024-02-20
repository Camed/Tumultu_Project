using Tumultu.Domain.Common;
using Tumultu.Domain.ValueObjects;

namespace Tumultu.Domain.Entities;

public class User : BaseEntity<Guid>
{
    public string Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public string Email { get; set; }
    public DateTimeOffset RegistrationDate { get; set; }
    public DateTimeOffset? LastLoginDate { get; set; }
    public DateTimeOffset? EmailVerificationDate { get; set; }
    public bool IsActive { get; set; }
    public IList<FileNote> Notes { get; set; } = [];
}
