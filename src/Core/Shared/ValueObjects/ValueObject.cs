using System.Collections.Generic;
using System.Linq;

namespace Shared.ValueObjects;

public abstract class ValueObject
{
    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != GetType())
            return false;

        return obj is ValueObject other && GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
        => GetEqualityComponents().Select(obj => (obj?.GetHashCode()) ?? 0).Aggregate((x, y) => x ^ y);

    private static bool EqualOperator(ValueObject left, ValueObject right)
    {
        if (left is null ^ right is null)
            return false;

        return left?.Equals(right) != false;
    }

    protected static bool NotEqualOperator(ValueObject left, ValueObject right) => !EqualOperator(left, right);

    protected abstract IEnumerable<object> GetEqualityComponents();
}