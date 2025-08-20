using Calculator.Utils.Interfaces.Maybe;

namespace Calculator.Commands;

public record UpdateOperatorCommand(IMaybe<string> Value);