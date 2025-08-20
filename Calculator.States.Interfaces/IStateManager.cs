using Calculator.Data;
using Calculator.States.Contexts;
using Calculator.States.Contexts.Interfaces;

namespace Calculator.States.Interfaces;

public interface IStateManager
{
    public IState State { get; }
    public CalculationNumbers Numbers { get; set; }
    public void SetState(IState state);
}