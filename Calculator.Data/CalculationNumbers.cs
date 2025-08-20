using Calculator.Utils;
using Calculator.Utils.Interfaces.Maybe;

namespace Calculator.Data;

public sealed record CalculationNumbers(
    double FirstNumber,
    double SecondNumber,
    IMaybe<string> Operator
)
{
    public static CalculationNumbers Reset() => new(
        FirstNumber: 0,
        SecondNumber: 0,
        Operator: Maybe<string>.None
    );
}