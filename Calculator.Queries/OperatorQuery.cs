using Calculator.Utils.Interfaces.Maybe;

namespace Calculator.Queries;

public sealed record OperatorQuery(IMaybe<string> Value);