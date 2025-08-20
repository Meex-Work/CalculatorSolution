using Calculator.Utils.Interfaces;
using Calculator.Utils.Interfaces.Maybe;

namespace Calculator.Utils;

public sealed record Maybe<TValue> :
    IMaybe<TValue>,
    IEquatable<IMaybe<TValue>>
{
    private readonly TValue? _value;
    public bool HasValue => _value != null;
    public bool HasNoValue => !HasValue;

    private Maybe(TValue? value) => _value = value;

    public static Maybe<TValue> Some(TValue? value) => new(value);
    public static readonly Maybe<TValue> None = new(default(TValue?));

    public bool If(Action<TValue> some)
    {
        if (HasNoValue) return false;

        some.Invoke(_value!);
        return true;
    }

    public bool IfNot(Action none)
    {
        if (HasNoValue) return false;

        none.Invoke();
        return true;
    }

    public TResult Match<TResult>(
        Func<TValue, TResult> some,
        Func<TResult> none
    ) => HasValue
        ? some(_value!)
        : none();

    public TValue OrThrow() => OrThrow("Value is not present.");
    public TValue OrThrow(string errorMessage) => OrThrow(new InvalidOperationException(errorMessage));
    public TValue OrThrow(Exception exception)
        => HasValue
            ? _value!
            : throw exception;

    public bool Equals(IMaybe<TValue>? other)
        => other != null
           && HasValue.Equals(other.HasValue)
           && EqualityComparer<TValue>.Default.Equals(_value, other.OrThrow());

    public override int GetHashCode()
    {
        unchecked
        {
            return (EqualityComparer<TValue>.Default.GetHashCode(OrThrow()!) * 397) ^ HasValue.GetHashCode();
        }
    }

    public override string ToString() => HasValue
        ? $"Maybe<{_value!.ToString()}>"
        : "Maybe<Nothing>";
}