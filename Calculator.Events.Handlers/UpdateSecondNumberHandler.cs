using Calculator.Commands;
using Calculator.Commands.Handlers.Interfaces;
using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Interfaces;

namespace Calculator.Events.Handlers;

public static class UpdateSecondNumberHandler
{
    public static IEventHandler<TEvent> Build<TEvent>(
        ICommandHandler<UpdateSecondNumberCommand> handler
    ) where TEvent : CalculatorEvent
        => new UpdateSecondNumberHandler<TEvent>(handler);
}

internal sealed class UpdateSecondNumberHandler<TEvent>(
    ICommandHandler<UpdateSecondNumberCommand> handler
) : IEventHandler<TEvent>
    where TEvent : CalculatorEvent
{
    public TEvent Handle(TEvent @event)
    {
        handler.Command(new UpdateSecondNumberCommand(double.Parse(@event.InputFieldText)));
        return @event;
    }
}