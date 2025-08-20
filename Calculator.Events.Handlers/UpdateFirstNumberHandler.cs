using Calculator.Commands;
using Calculator.Commands.Handlers.Interfaces;
using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Interfaces;

namespace Calculator.Events.Handlers;

public static class UpdateFirstNumberHandler
{
    public static IEventHandler<TEvent> Build<TEvent>(
        ICommandHandler<UpdateFirstNumberCommand> handler
    ) where TEvent : CalculatorEvent
        => new UpdateFirstNumberHandler<TEvent>(handler);
}

internal sealed class UpdateFirstNumberHandler<TEvent>(
    ICommandHandler<UpdateFirstNumberCommand> handler
) : IEventHandler<TEvent>
    where TEvent : CalculatorEvent
{
    public TEvent Handle(TEvent @event)
    {
        handler.Command(new UpdateFirstNumberCommand(double.Parse(@event.InputFieldText)));
        return @event;
    }
}