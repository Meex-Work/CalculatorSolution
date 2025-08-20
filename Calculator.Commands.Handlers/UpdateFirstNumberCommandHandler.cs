using Calculator.Commands.Handlers.Interfaces;
using Calculator.States.Interfaces;

namespace Calculator.Commands.Handlers;

public sealed class UpdateFirstNumberCommandHandler(
    IStateManager stateManager
) : ICommandHandler<UpdateFirstNumberCommand>
{
    public void Command(UpdateFirstNumberCommand command) =>
        stateManager.Numbers = stateManager.Numbers with
        {
            FirstNumber = command.Value
        };
}