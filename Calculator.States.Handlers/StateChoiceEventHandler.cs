using Calculator.States.Contexts.Interfaces;
using Calculator.States.Interfaces;
using Calculator.Utils;

namespace Calculator.States.Handlers;

/// <summary>
/// Provides factory methods for creating conditional state event handlers.
/// </summary>
public static class StateChoiceEventHandler
{
    /// <summary>
    /// Creates a conditional state event handler that routes events based on a predicate.
    /// </summary>
    /// <typeparam name="TEvent">The type of event to evaluate and handle</typeparam>
    /// <param name="condition">Predicate that determines which handler will process the event</param>
    /// <param name="trueStateEventHandler">Handler used when condition evaluates to true</param>
    /// <param name="falseStateEventHandler">Handler used when condition evaluates to false</param>
    /// <returns>A configured conditional state event handler</returns>
    /// <example>
    /// <code>
    /// var handler = StateChoiceEventHandler.Build(
    ///     e => e.IsValid,
    ///     validHandler,
    ///     invalidHandler
    /// );
    /// </code>
    /// </example>
    public static IStateEventHandler<TEvent> Build<TEvent>(
        Predicate<TEvent> condition,
        IStateEventHandler<TEvent> trueStateEventHandler,
        IStateEventHandler<TEvent> falseStateEventHandler
    ) => new StateChoiceEventHandler<TEvent>(
        condition,
        trueStateEventHandler,
        falseStateEventHandler
    );
}

internal sealed class StateChoiceEventHandler<TEvent> :
    IStateEventHandler<TEvent>,
    IStateTransitionEventHandler<TEvent>
{
    private readonly Predicate<TEvent> _condition;
    private readonly IStateEventHandler<TEvent> _trueStateEventHandler;
    private readonly IStateEventHandler<TEvent> _falseStateEventHandler;

    private Maybe<TEvent> _event = Maybe<TEvent>.None;

    internal StateChoiceEventHandler(
        Predicate<TEvent> condition,
        IStateEventHandler<TEvent> trueStateEventHandler,
        IStateEventHandler<TEvent> falseStateEventHandler
    )
    {
        _condition = condition;
        _trueStateEventHandler = trueStateEventHandler;
        _falseStateEventHandler = falseStateEventHandler;
    }

    public IStateTransitionEventHandler<TEvent> Handle(TEvent @event)
    {
        _event = Maybe<TEvent>.Some(@event);
        return this;
    }

    public TEvent UpdateState(Action<IState> transitionAction)
    {
        var handler = _condition(_event.OrThrow())
            ? _trueStateEventHandler
            : _falseStateEventHandler;

        return handler
            .Handle(_event.OrThrow())
            .UpdateState(transitionAction);
    }
}