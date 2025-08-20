using Calculator.Queries.Handlers.Interfaces;
using Calculator.States.Interfaces;

namespace Calculator.Queries.Handlers;

public sealed class SecondNumberQueryHandler(IStateManager stateManager) : IQueryHandler<SecondNumberQuery>
{
    public SecondNumberQuery Query() => new(stateManager.Numbers.SecondNumber);
}