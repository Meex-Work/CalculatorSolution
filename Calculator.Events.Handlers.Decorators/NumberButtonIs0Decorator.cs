using Calculator.Events.Handlers.Interfaces;

namespace Calculator.Events.Handlers.Decorators;

public sealed class NumberButtonIs0Decorator(
    IEventHandler<ClickedNumberButtonEvent> decoratee
) : IEventHandler<ClickedNumberButtonEvent>
{
    public ClickedNumberButtonEvent Handle(ClickedNumberButtonEvent @event) =>
        int.TryParse(@event.Number, out var number)
        && number is 0
            ? decoratee.Handle(@event)
            : @event;
}