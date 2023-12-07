using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tumultu.Domain.Common;

/// <summary>
/// Value object created with Microsoft guidelines.
/// Find more here: https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects
/// </summary>
public abstract class ValueObject
{
    protected abstract IEnumerable<object> GetEqualityComponents();
    protected static bool EqualOperator(ValueObject l, ValueObject r)
    {
        // ^ is XOR operator (XD)
        if(l is null ^ r is null)
        {
            return false;
        }
        return ReferenceEquals(l, r) || l!.Equals(r);
    }

    protected static bool NotEqualOperator(ValueObject l, ValueObject r)
    {
        return !EqualOperator(l, r);
    }

    public override bool Equals(object? obj)
    {
        if(obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject)obj;

        return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x is not null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }

    public static bool operator ==(ValueObject left, ValueObject right)
    {
        return EqualOperator(left, right);
    }

    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return NotEqualOperator(left, right);
    }
}
