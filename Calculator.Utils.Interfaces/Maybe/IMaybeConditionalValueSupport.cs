namespace Calculator.Utils.Interfaces.Maybe;

public interface IMaybeConditionalValueSupport<out TValue>
{
    public bool If(Action<TValue> some);
    public bool IfNot(Action none);

    public TResult Match<TResult>(
        Func<TValue, TResult> some,
        Func<TResult> none
    );
}