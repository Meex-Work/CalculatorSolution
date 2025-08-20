namespace Calculator.Commands.Handlers.Interfaces;

/// <summary>
/// Defines a handler for a specific command type in a command pattern implementation.
/// </summary>
/// <typeparam name="TCommand">The type of command being handled (contravariant)</typeparam>
public interface ICommandHandler<in TCommand>
{
    /// <summary>
    /// Handles the specified command.
    /// </summary>
    /// <param name="command">The command object to handle</param>
    public void Command(TCommand command);
}