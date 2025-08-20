using Calculator.Services.Interfaces;
using Calculator.Services.Inputs;
using Calculator.Services.Results;

namespace Calculator.Services;

public sealed class CalculationMultiplyService : IService<CalculationInput, CalculationResult>
{
    public CalculationResult Execute(CalculationInput input) => new(input.First * input.Second);
}