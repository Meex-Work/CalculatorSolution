namespace Calculator.Utils.Interfaces.Maybe;

public interface IMaybe<TValue> :
    IMaybeCheckValueSupport,
    IMaybeConditionalValueSupport<TValue>,
    IMaybeExceptionSupport<TValue>;