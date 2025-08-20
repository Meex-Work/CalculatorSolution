using System.Reflection;
using Calculator.Services.Contexts.Interfaces;

namespace Calculator.Services.Contexts;

public sealed record Operation : IOperation
{
    public static IOperation Add { get; } = new Operation(nameof(Add), "+");
    public static IOperation Subtract { get; } = new Operation(nameof(Subtract), "-");
    public static IOperation Multiply { get; } = new Operation(nameof(Multiply), "×");
    public static IOperation Divide { get; } = new Operation(nameof(Divide), "÷");

    // new operations need to be declared above this
    private static readonly OperationList List = new(InternalList());
    public static readonly IOperationListNames Names = List;
    public static readonly IOperationListValues Values = List;

    private static List<IOperation> InternalList() =>
        typeof(Operation)
            .GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Where(info => info.PropertyType == typeof(IOperation))
            .Select(info => (IOperation)info.GetValue(null, null)!)
            .ToList();

    public string Name { get; }

    public string Value { get; }

    private Operation(
        string name,
        string value
    )
    {
        Name = name;
        Value = value;
    }
}