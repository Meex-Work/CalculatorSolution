using Calculator.Commands;
using Calculator.Commands.Handlers.Interfaces;
using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Interfaces;
using Calculator.Utils;

namespace Calculator.Events.Handlers;

public static class ResetOperatorHandler
{
    public static IEventHandler<TEvent> Build<TEvent>(
        ICommandHandler<UpdateOperatorCommand> handler
    ) where TEvent : CalculatorEvent
        => new ResetOperatorHandler<TEvent>(handler);
}

internal sealed class ResetOperatorHandler<TEvent>(
    ICommandHandler<UpdateOperatorCommand> handler
) : IEventHandler<TEvent>
{
    public TEvent Handle(TEvent @event)
    {
        handler.Command(new UpdateOperatorCommand(Maybe<string>.None));
        return @event;
    }
}