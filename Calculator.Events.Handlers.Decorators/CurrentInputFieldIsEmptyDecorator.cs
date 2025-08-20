using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Interfaces;

namespace Calculator.Events.Handlers.Decorators;

public sealed class CurrentInputFieldIsEmptyDecorator<TEvent>(
    IEventHandler<TEvent> decoratee
) : IEventHandler<TEvent>
    where TEvent : CalculatorEvent
{
    public TEvent Handle(TEvent @event) =>
        @event.InputFieldText.Length <= 1
            ? decoratee.Handle(@event)
            : @event;
}