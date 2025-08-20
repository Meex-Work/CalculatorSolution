using Calculator.Events.Handlers.Interfaces;
using Calculator.States.Contexts.Interfaces;
using Calculator.States.Interfaces;
using Calculator.Utils;

namespace Calculator.States.Handlers;

/// <summary>
/// Provides factory methods for creating state event handlers and their builders.
/// </summary>
public static class StateEventHandler
{
    /// <summary>
    /// Creates a builder for configuring a state event handler with the specified event processor.
    /// </summary>
    /// <typeparam name="TEvent">The type of event to be handled</typeparam>
    /// <param name="eventHandler">The underlying event processor that will handle the event content</param>
    /// <returns>A transition builder for configuring the state change behavior</returns>
    /// <example>
    /// <code>
    /// var handler = StateEventHandler.Build(myEventHandler)
    ///     .TransitionTo(nextState);
    /// </code>
    /// </example>
    public static IStateEventHandlerTransitionBuilder<TEvent> Build<TEvent>(IEventHandler<TEvent> eventHandler)
        => new StateEventHandler<TEvent>.Builder(eventHandler);
}

internal sealed class StateEventHandler<TEvent> :
    IStateEventHandler<TEvent>,
    IStateTransitionEventHandler<TEvent>
{
    private Maybe<TEvent> _event = Maybe<TEvent>.None;
    private readonly IEventHandler<TEvent> _eventHandler;
    private readonly IState _nextState;

    private StateEventHandler(
        IEventHandler<TEvent> eventHandler,
        IState nextState
    )
    {
        _eventHandler = eventHandler;
        _nextState = nextState;
    }

    public IStateTransitionEventHandler<TEvent> Handle(TEvent @event)
    {
        _event = Maybe<TEvent>.Some(@event);
        return this;
    }

    public TEvent UpdateState(Action<IState> transitionAction)
    {
        var @event = _eventHandler.Handle(_event.OrThrow());
        transitionAction(_nextState);
        return @event;
    }

    internal sealed class Builder : IStateEventHandlerTransitionBuilder<TEvent>
    {
        private readonly IEventHandler<TEvent> _eventHandler;

        internal Builder(IEventHandler<TEvent> eventHandler) => _eventHandler = eventHandler;

        public IStateEventHandler<TEvent> TransitionTo(IState nextState)
            => new StateEventHandler<TEvent>(_eventHandler, nextState);
    }
}