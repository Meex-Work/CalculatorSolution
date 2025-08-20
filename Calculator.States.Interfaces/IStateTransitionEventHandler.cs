using Calculator.States.Contexts.Interfaces;

namespace Calculator.States.Interfaces;

/// <summary>
/// Defines a handler for completing state transitions after event processing.
/// </summary>
/// <typeparam name="TEvent">The covariant type of event being handled</typeparam>
/// <remarks>
/// This interface completes the state transition process by executing
/// the actual state change after event processing.
/// The covariant (<c>out</c>) parameter allows for more specific return types.
/// </remarks>
public interface IStateTransitionEventHandler<out TEvent>
{
    /// <summary>
    /// Finalizes the state transition by updating the current state.
    /// </summary>
    /// <param name="transitionAction">The action that performs the state transition</param>
    /// <returns>The processed event (potentially modified)</returns>
    public TEvent UpdateState(Action<IState> transitionAction);
}