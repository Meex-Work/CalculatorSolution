using Calculator.Commands;
using Calculator.Commands.Handlers.Interfaces;
using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Interfaces;

namespace Calculator.Events.Handlers;

public static class ResetSecondNumberHandler
{
    public static IEventHandler<TEvent> Build<TEvent>(
        ICommandHandler<UpdateSecondNumberCommand> handler
    ) where TEvent : CalculatorEvent
        => new ResetSecondNumberHandler<TEvent>(handler);
}

internal sealed class ResetSecondNumberHandler<TEvent>(
    ICommandHandler<UpdateSecondNumberCommand> handler
) : IEventHandler<TEvent>
{
    public TEvent Handle(TEvent @event)
    {
        handler.Command(new UpdateSecondNumberCommand(0));
        return @event;
    }
}