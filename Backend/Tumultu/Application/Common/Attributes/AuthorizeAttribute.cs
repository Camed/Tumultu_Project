using Tumultu.Domain.Constants;

namespace Tumultu.Application.Common.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class AuthorizeAttribute : Attribute
{
    public AuthorizeAttribute() { }

    public IEnumerable<Roles> Roles { get; set; } = new List<Roles>();
}
