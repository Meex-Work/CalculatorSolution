using Calculator.Utils.Interfaces.Maybe;

namespace Calculator.States.Contexts.Interfaces;

public interface IStateList
{
    public IState FromName(string state);
    public IState FromName(IMaybe<string> state);
}