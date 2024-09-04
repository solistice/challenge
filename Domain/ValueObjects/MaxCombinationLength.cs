using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects;

public class MaxCombinationLength : ValueObject
{
    public int Value { get; }

    public static MaxCombinationLength Create(int value)
    {
        if (value <= 1)
            throw new ArgumentOutOfRangeException(nameof(value), "MaxCombinationLength should at least be 2 to make sense");

        return new MaxCombinationLength(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private MaxCombinationLength(int value) => Value = value;
}
