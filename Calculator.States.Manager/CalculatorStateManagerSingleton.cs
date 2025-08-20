using Calculator.Data;
using Calculator.States.Contexts.Interfaces;
using Calculator.States.Interfaces;

namespace Calculator.States.Manager;

public sealed class CalculatorStateManagerSingleton(IStateList states) : IStateManager
{
    public IState State { get; private set; } = Contexts.State.Start;
    public CalculationNumbers Numbers { get; set; } = CalculationNumbers.Reset();
    public void SetState(IState state) => State = state;
}