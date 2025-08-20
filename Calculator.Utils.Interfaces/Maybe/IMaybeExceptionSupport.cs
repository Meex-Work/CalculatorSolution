namespace Calculator.Utils.Interfaces.Maybe;

public interface IMaybeExceptionSupport<TValue>
{
    public TValue OrThrow();
    public TValue OrThrow(string errorMessage);
    public TValue OrThrow(Exception exception);
}