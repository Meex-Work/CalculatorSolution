namespace Calculator.Utils.Interfaces.Maybe;

public interface IMaybeCheckValueSupport
{
    public bool HasValue { get; }
    public bool HasNoValue { get; }
}