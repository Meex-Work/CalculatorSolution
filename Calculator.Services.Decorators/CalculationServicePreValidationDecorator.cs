using Calculator.Services.Interfaces;
using Calculator.Services.Inputs;
using Calculator.Services.Results;

namespace Calculator.Services.Decorators;

public sealed class CalculationServicePreValidationDecorator : IService<CalculationInput, CalculationResult>
{
    private readonly IService<CalculationInput, CalculationResult> _decoratee;
    private readonly Predicate<CalculationInput> _inputValidator;

    private CalculationServicePreValidationDecorator(
        IService<CalculationInput, CalculationResult> decoratee,
        Predicate<CalculationInput> inputValidator
    )
    {
        _decoratee = decoratee;
        _inputValidator = inputValidator;
    }

    public static IService<CalculationInput, CalculationResult> Decorate(
        IService<CalculationInput, CalculationResult> decoratee,
        Predicate<CalculationInput> inputValidator
    ) => new CalculationServicePreValidationDecorator(decoratee, inputValidator);

    public static IService<CalculationInput, CalculationResult> SecondNumberIsNotNull(
        IService<CalculationInput, CalculationResult> decoratee
    ) => Decorate(
        decoratee,
        input => input.Second != 0
    );

    public CalculationResult Execute(CalculationInput input)
    {
        if (_inputValidator(input))
        {
            return _decoratee.Execute(input);
        }

        throw new Exception("Invalid input");
    }
}