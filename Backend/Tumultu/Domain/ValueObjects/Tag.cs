using Tumultu.Domain.Common;

namespace Tumultu.Domain.ValueObjects;

public class Tag : ValueObject
{
    public Tag() { }
    public Tag(string? name)
    {
        Name = name;
    }

    public string? Name { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name!;
    }
}
