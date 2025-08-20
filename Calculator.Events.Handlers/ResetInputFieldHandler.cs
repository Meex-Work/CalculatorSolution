using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Interfaces;

namespace Calculator.Events.Handlers;

public static class ResetInputFieldHandler
{
    public static IEventHandler<TEvent> Build<TEvent>()
        where TEvent : CalculatorEvent
        => new ResetInputFieldHandler<TEvent>();
}

internal sealed class ResetInputFieldHandler<TEvent> :
    IEventHandler<TEvent>
    where TEvent : CalculatorEvent
{
    public TEvent Handle(TEvent @event) =>
        @event with
        {
            InputFieldText = "0"
        };
}