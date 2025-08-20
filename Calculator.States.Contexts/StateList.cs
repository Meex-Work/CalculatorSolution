using Calculator.States.Contexts.Interfaces;
using Calculator.Utils.Interfaces.Maybe;

namespace Calculator.States.Contexts;

internal sealed class StateList(IEnumerable<IState> states) : IStateList
{
    public IState FromName(string state) => states
        .Single(r => string.Equals(r.Name, state, StringComparison.OrdinalIgnoreCase));

    public IState FromName(IMaybe<string> state) =>
        state.Match(
            some: FromName,
            none: () => throw new InvalidOperationException()
        );
}