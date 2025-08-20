using Calculator.Events.Handlers.Interfaces;

namespace Calculator.Events.Handlers.Decorators;

public sealed class NumberButtonIsBetween1And9Decorator(
    IEventHandler<ClickedNumberButtonEvent> decoratee
) : IEventHandler<ClickedNumberButtonEvent>
{
    public ClickedNumberButtonEvent Handle(ClickedNumberButtonEvent @event) =>
        int.TryParse(@event.Number, out var number)
        && number is >= 1 and <= 9
            ? decoratee.Handle(@event)
            : @event;
}