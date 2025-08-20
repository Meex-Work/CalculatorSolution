using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Interfaces;

namespace Calculator.Events.Handlers;

public static class RemoveLastNumberFromInputFieldHandler
{
    public static IEventHandler<TEvent> Build<TEvent>()
        where TEvent : CalculatorEvent
        => new RemoveLastNumberFromInputFieldHandler<TEvent>();
}

internal sealed class RemoveLastNumberFromInputFieldHandler<TEvent> :
    IEventHandler<TEvent>
    where TEvent : CalculatorEvent
{
    public TEvent Handle(TEvent @event) => @event with
    {
        InputFieldText = @event.InputFieldText[..^1]
    };
}