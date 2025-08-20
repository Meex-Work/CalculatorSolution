using System.Reflection;
using Calculator.States.Contexts.Interfaces;

namespace Calculator.States.Contexts;

public sealed record State : IState
{
    public static IState Start { get; } = new State(nameof(Start));
    public static IState FirstNumber { get; } = new State(nameof(FirstNumber));
    public static IState FirstNumberDecimal { get; } = new State(nameof(FirstNumberDecimal));
    public static IState Operator { get; } = new State(nameof(Operator));
    public static IState SecondNumber { get; } = new State(nameof(SecondNumber));
    public static IState SecondNumberDecimal { get; } = new State(nameof(SecondNumberDecimal));
    public static IState Result { get; } = new State(nameof(Result));

    // new operations need to be declared above this
    public static readonly IStateList List = new StateList(InternalList());

    private static List<IState> InternalList() =>
        typeof(State)
            .GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Where(info => info.PropertyType == typeof(IState))
            .Select(info => (IState)info.GetValue(null, null)!)
            .OrderBy(operation => operation.Name)
            .ToList();

    public string Name { get; }

    private State(string name)
    {
        Name = name;
    }
}