namespace Domain.ValueObjects;

public class TargetLength : ValueObject
{
    public int Value { get; }

    public static TargetLength Create(int value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Target length should at least be 1 to make sense");

        return new TargetLength(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private TargetLength(int value) => Value = value;

}
