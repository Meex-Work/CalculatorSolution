using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Interfaces;

namespace Calculator.Events.Handlers;

public static class NoActionEventHandler
{
    public static IEventHandler<TEvent> Build<TEvent>()
        where TEvent : CalculatorEvent
        => new NoActionEventHandler<TEvent>();
}

internal sealed class NoActionEventHandler<TEvent>
    : IEventHandler<TEvent>
{
    public TEvent Handle(TEvent @event) => @event;
}