using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Interfaces;

namespace Calculator.Events.Handlers;

public static class ResetDisplayFieldHandler
{
    public static IEventHandler<TEvent> Build<TEvent>()
        where TEvent : CalculatorEvent
        => new ResetDisplayFieldHandler<TEvent>();
}

internal sealed class ResetDisplayFieldHandler<TEvent> :
    IEventHandler<TEvent>
    where TEvent : CalculatorEvent
{
    public TEvent Handle(TEvent @event) => @event with
    {
        OperationLabelText = string.Empty
    };
}