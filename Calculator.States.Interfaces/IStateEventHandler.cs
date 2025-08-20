namespace Calculator.States.Interfaces;

/// <summary>
/// Defines a handler for state-related events in a state machine pattern.
/// </summary>
/// <typeparam name="TEvent">The type of event being handled</typeparam>
/// <remarks>
/// This interface initiates the state transition process by handling an event
/// and returning a transition handler for subsequent state updates.
/// </remarks>
public interface IStateEventHandler<TEvent>
{
    /// <summary>
    /// Processes the state event and prepares for state transition.
    /// </summary>
    /// <param name="event">The event triggering the state transition</param>
    /// <returns>A transition handler to complete the state change</returns>
    public IStateTransitionEventHandler<TEvent> Handle(TEvent @event);
}