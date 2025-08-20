using Calculator.Commands;
using Calculator.Commands.Handlers.Interfaces;
using Calculator.Events.Handlers.Interfaces;
using Calculator.Utils;

namespace Calculator.Events.Handlers;

public sealed class UpdateOperatorHandler(
    ICommandHandler<UpdateOperatorCommand> handler
) : IEventHandler<ClickedOperatorButtonEvent>

{
    public ClickedOperatorButtonEvent Handle(ClickedOperatorButtonEvent @event)
    {
        handler.Command(new UpdateOperatorCommand(Maybe<string>.Some(@event.Operator)));
        return @event;
    }
}