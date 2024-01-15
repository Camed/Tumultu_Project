using Tumultu.Domain.Common;
using Tumultu.Domain.ValueObjects;

namespace Tumultu.Domain.Entities;

public class User : BaseEntity<Guid>
{
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PasswordHash { get; set; }
    public string? PasswordSalt { get; set; }
    public string? Email { get; set; }
    public string? RegistrationDate { get; set; }
    public string? LastLoginDate { get; set; }
    public string? EmailVerificationDate { get; set; }
    public bool IsActive { get; set; } = false;
    public IEnumerable<FileNote>? Notes { get; set; }
}
