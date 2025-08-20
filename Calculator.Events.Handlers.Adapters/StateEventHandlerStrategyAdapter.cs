using Calculator.Events.Handlers.Interfaces;
using Calculator.States.Contexts.Interfaces;
using Calculator.States.Interfaces;
using DependencyInjection.Strategies.Interfaces;

namespace Calculator.Events.Handlers.Adapters;

public static class StateEventHandlerStrategyAdapter
{
    public static IEventHandler<TEvent> Adapt<TEvent>(
        IStateManager stateManager,
        IStrategy<IState, IStateEventHandler<TEvent>> strategies
    ) => new StateEventHandlerStrategyAdapter<TEvent>(
        stateManager,
        strategies
    );
}

internal sealed class StateEventHandlerStrategyAdapter<TEvent>(
    IStateManager stateManager,
    IStrategy<IState, IStateEventHandler<TEvent>> strategies
) : IEventHandler<TEvent>
{
    public TEvent Handle(TEvent @event) => strategies
        .Get(stateManager.State)
        .Handle(@event)
        .UpdateState(stateManager.SetState);
}