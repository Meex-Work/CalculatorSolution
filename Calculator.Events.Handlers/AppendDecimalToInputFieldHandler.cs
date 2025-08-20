using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Interfaces;

namespace Calculator.Events.Handlers;

public static class AppendDecimalToInputFieldHandler
{
    public static IEventHandler<TEvent> Build<TEvent>()
        where TEvent : CalculatorEvent
        => new AppendDecimalToInputFieldHandler<TEvent>();
}

internal sealed class AppendDecimalToInputFieldHandler<TEvent> :
    IEventHandler<TEvent>
    where TEvent : CalculatorEvent
{
    public TEvent Handle(TEvent @event) => @event with
    {
        InputFieldText = @event.InputFieldText + "."
    };
}