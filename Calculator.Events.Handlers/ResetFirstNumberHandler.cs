using Calculator.Commands;
using Calculator.Commands.Handlers.Interfaces;
using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Interfaces;

namespace Calculator.Events.Handlers;

public static class ResetFirstNumberHandler
{
    public static IEventHandler<TEvent> Build<TEvent>(
        ICommandHandler<UpdateFirstNumberCommand> handler
    ) where TEvent : CalculatorEvent
        => new ResetFirstNumberHandler<TEvent>(handler);
}

internal sealed class ResetFirstNumberHandler<TEvent>(
    ICommandHandler<UpdateFirstNumberCommand> handler
) : IEventHandler<TEvent>
{
    public TEvent Handle(TEvent @event)
    {
        handler.Command(new UpdateFirstNumberCommand(0));
        return @event;
    }
}