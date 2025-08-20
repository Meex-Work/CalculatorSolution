using Calculator.States.Contexts.Interfaces;

namespace Calculator.States.Interfaces;

/// <summary>
/// Defines a builder for creating state event handlers with associated transitions.
/// </summary>
/// <typeparam name="TEvent">The type of event being handled</typeparam>
/// <remarks>
/// This builder pattern allows fluent configuration of state transitions
/// following event handling.
/// </remarks>
public interface IStateEventHandlerTransitionBuilder<TEvent>
{
    /// <summary>
    /// Specifies the target state for the transition.
    /// </summary>
    /// <param name="nextState">The state to transition to</param>
    /// <returns>A configured state event handler</returns>
    public IStateEventHandler<TEvent> TransitionTo(IState nextState);
}