using Calculator.Queries.Handlers.Interfaces;
using Calculator.States.Interfaces;

namespace Calculator.Queries.Handlers;

public sealed class OperatorQueryHandler(IStateManager stateManager) : IQueryHandler<OperatorQuery>
{
    public OperatorQuery Query() => new(stateManager.Numbers.Operator);
}