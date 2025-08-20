using Calculator.Commands.Handlers.Interfaces;
using Calculator.States.Interfaces;

namespace Calculator.Commands.Handlers;

public sealed class UpdateOperatorCommandHandler(
    IStateManager stateManager
) : ICommandHandler<UpdateOperatorCommand>
{
    public void Command(UpdateOperatorCommand command) =>
        stateManager.Numbers = stateManager.Numbers with
        {
            Operator = command.Value
        };
}