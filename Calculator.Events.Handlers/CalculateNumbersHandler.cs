using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Interfaces;
using Calculator.Queries;
using Calculator.Queries.Handlers.Interfaces;
using Calculator.Services.Inputs;
using Calculator.Services.Interfaces;
using Calculator.Services.Results;

namespace Calculator.Events.Handlers;

public static class CalculateNumbersHandler
{
    public static IEventHandler<TEvent> Build<TEvent>(
        IQueryHandler<FirstNumberQuery> firstNumberHandler,
        IQueryHandler<SecondNumberQuery> secondNumberHandler,
        IService<CalculationInput, CalculationResult> calculationService
    ) where TEvent : CalculatorEvent
        => new CalculateNumbersHandler<TEvent>(
            firstNumberHandler,
            secondNumberHandler,
            calculationService
        );
}

internal sealed class CalculateNumbersHandler<TEvent>(
    IQueryHandler<FirstNumberQuery> firstNumberHandler,
    IQueryHandler<SecondNumberQuery> secondNumberHandler,
    IService<CalculationInput, CalculationResult> calculationService
) : IEventHandler<TEvent> where TEvent : CalculatorEvent
{
    public TEvent Handle(TEvent @event)
    {
        var calculation = calculationService
            .Execute(
                new CalculationInput(
                    firstNumberHandler.Query().Value,
                    secondNumberHandler.Query().Value
                )
            );

        return @event with
        {
            InputFieldText = $"{calculation.Result}"
        };
    }
}