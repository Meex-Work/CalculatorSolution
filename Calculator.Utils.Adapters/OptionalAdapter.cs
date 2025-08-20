using Calculator.Utils.Interfaces;
using Calculator.Utils.Interfaces.Maybe;
using Optional;
using Optional.Unsafe;

namespace Calculator.Utils.Adapters;

internal sealed record OptionalAdapter<TValue> : IMaybe<TValue>
{
    private readonly Option<TValue> _value;

    private OptionalAdapter(Option<TValue> value) => _value = value;

    public static IMaybe<TValue> Some(TValue value) => new OptionalAdapter<TValue>(Option.Some(value));
    public static IMaybe<TValue> None => new OptionalAdapter<TValue>(Option.None<TValue>());

    public bool HasValue => _value.HasValue;
    public bool HasNoValue => !HasValue;

    public bool If(Action<TValue> some)
    {
        if (!HasNoValue) return false;

        _value.MatchSome(some);
        return true;
    }

    public bool IfNot(Action none)
    {
        if (HasValue) return false;

        _value.MatchNone(none);
        return true;
    }

    public TResult Match<TResult>(
        Func<TValue, TResult> some,
        Func<TResult> none
    ) => _value.Match(some, none);

    public TValue OrThrow() => OrThrow("No Value!");

    public TValue OrThrow(string errorMessage) => _value.ValueOrFailure(() => errorMessage);

    public TValue OrThrow(Exception exception)
    {
        if (HasNoValue)
        {
            return _value.ValueOrDefault();
        }
        
        throw exception;
    }
}