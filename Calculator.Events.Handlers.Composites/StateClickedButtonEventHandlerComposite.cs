using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Interfaces;
using Calculator.Utils.Interfaces.Logging;

namespace Calculator.Events.Handlers.Composites;

public sealed class StateClickedButtonEventHandlerComposite<TEvent>(
    IDebugLogger debugLogger,
    IEnumerable<IEventHandler<TEvent>> composite
) : IEventHandler<TEvent>
    where TEvent : CalculatorEvent
{
    public TEvent Handle(TEvent @event)
    {
        var eventStep = 0;
        var eventId = Guid.NewGuid();
        var eventName = typeof(TEvent).Name;

        debugLogger.Debug($"Start handling: Id = {eventId}, Name = {eventName}");

        foreach (var handler in composite)
        {
            debugLogger.Debug($"Step = {++eventStep}, Id = {eventId}, Name = {eventName}");

            var handlerName = handler.GetType().Name;
            debugLogger.Debug($"Current handler = {handlerName}, Input = {@event}");

            @event = handler.Handle(@event);

            debugLogger.Debug($"Current handler = {handlerName}. Result = {@event}");
        }

        debugLogger.Debug($"Stop handling: Id = {eventId}, Name = {eventName}, Steps = {eventStep}");

        return @event;
    }
}