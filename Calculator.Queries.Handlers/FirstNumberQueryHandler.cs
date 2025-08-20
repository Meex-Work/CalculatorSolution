using Calculator.Queries.Handlers.Interfaces;
using Calculator.States.Interfaces;

namespace Calculator.Queries.Handlers;

public sealed class FirstNumberQueryHandler(IStateManager stateManager) : IQueryHandler<FirstNumberQuery>
{
    public FirstNumberQuery Query() => new(stateManager.Numbers.FirstNumber);
}