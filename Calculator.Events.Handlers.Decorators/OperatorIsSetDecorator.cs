using Calculator.Events.Handlers.Interfaces;
using Calculator.States.Interfaces;

namespace Calculator.Events.Handlers.Decorators;

public sealed class OperatorIsSetDecorator<TEvent>(
    IStateManager stateManager,
    IEventHandler<TEvent> decoratee
) : IEventHandler<TEvent>
{
    public TEvent Handle(TEvent @event) => stateManager.Numbers.Operator.HasValue
        ? decoratee.Handle(@event)
        : @event;
}