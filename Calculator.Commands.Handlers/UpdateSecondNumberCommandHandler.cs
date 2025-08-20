using Calculator.Commands.Handlers.Interfaces;
using Calculator.States.Interfaces;

namespace Calculator.Commands.Handlers;

public sealed class UpdateSecondNumberCommandHandler(
    IStateManager stateManager
) : ICommandHandler<UpdateSecondNumberCommand>
{
    public void Command(UpdateSecondNumberCommand command) =>
        stateManager.Numbers = stateManager.Numbers with
        {
            SecondNumber = command.Value
        };
}