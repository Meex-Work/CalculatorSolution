using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Interfaces;

namespace Calculator.Events.Handlers.Decorators;

public sealed class CurrentInputDoesNotContainDecimalDecorator<TEvent>(
    IEventHandler<TEvent> decoratee
) : IEventHandler<TEvent>
    where TEvent : CalculatorEvent
{
    public TEvent Handle(TEvent @event) =>
        !@event.InputFieldText.Contains('.')
            ? decoratee.Handle(@event)
            : @event;
}