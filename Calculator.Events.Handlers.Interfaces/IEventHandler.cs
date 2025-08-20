namespace Calculator.Events.Handlers.Interfaces;

/// <summary>
/// Defines a handler for a specific event type in an event-driven architecture.
/// </summary>
/// <typeparam name="TEvent">The type of event being handled</typeparam>
public interface IEventHandler<TEvent>
{
    /// <summary>
    /// Processes the specified event and returns the potentially modified event.
    /// </summary>
    /// <param name="event">The event object to handle</param>
    /// <returns>The processed event, which may be the same instance or a new modified instance</returns>
    /// <remarks>
    /// Implementations should:
    /// <list type="bullet">
    /// <item><description>Handle the event processing logic</description></item>
    /// <item><description>Return either the original event or a modified version</description></item>
    /// <item><description>Handle any expected exceptions internally</description></item>
    /// </list>
    /// </remarks>
    public TEvent Handle(TEvent @event);
}