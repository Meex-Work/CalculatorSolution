using Calculator.Commands;
using Calculator.Commands.Handlers.Interfaces;
using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Interfaces;
using DependencyInjection.Interfaces;

namespace Calculator.Events.Handlers.Composites;

public static class EventHandlerComposite
{
    public static IEventHandler<TEvent> Sequence<TEvent>(
        params IEventHandler<TEvent>[] sequence
    ) where TEvent : CalculatorEvent
        => new EventHandlerComposite<TEvent>(sequence);

    public static IEventHandler<TEvent> ClearAll<TEvent>(IDependencyProvider provider)
        where TEvent : CalculatorEvent
        => Sequence(
            ResetDisplayFieldHandler.Build<TEvent>(),
            ResetInputFieldHandler.Build<TEvent>(),
            ResetFirstNumberHandler.Build<TEvent>(provider.Resolve<ICommandHandler<UpdateFirstNumberCommand>>()),
            ResetOperatorHandler.Build<TEvent>(provider.Resolve<ICommandHandler<UpdateOperatorCommand>>()),
            ResetSecondNumberHandler.Build<TEvent>(provider.Resolve<ICommandHandler<UpdateSecondNumberCommand>>())
        );
}

internal sealed class EventHandlerComposite<TEvent> :
    IEventHandler<TEvent>
    where TEvent : CalculatorEvent
{
    private readonly IEnumerable<IEventHandler<TEvent>> _composite;

    private EventHandlerComposite(
        IEnumerable<IEventHandler<TEvent>> composite
    ) => _composite = composite;

    internal EventHandlerComposite(
        params IEventHandler<TEvent>[] composite
    ) : this(composite.AsEnumerable())
    {
    }

    public TEvent Handle(TEvent @event) => _composite
        .Aggregate(
            @event,
            (current, handler) => handler.Handle(current)
        );
}