using Calculator.Services.Contexts.Interfaces;
using Calculator.Utils.Interfaces.Maybe;

namespace Calculator.Services.Contexts;

internal sealed class OperationList(
    IEnumerable<IOperation> operations
) :
    IOperationListNames,
    IOperationListValues
{
    public IOperation FromName(string operation) => operations
        .Single(r => string.Equals(r.Name, operation, StringComparison.OrdinalIgnoreCase));

    public IOperation FromName(IMaybe<string> operation) =>
        operation.Match(
            some: FromName,
            none: () => throw new InvalidOperationException()
        );

    public IOperation FromValue(string value) => operations
        .Single(r => r.Value == value);

    public IOperation FromValue(IMaybe<string> operation) =>
        operation.Match(
            some: FromValue,
            none: () => throw new InvalidOperationException()
        );
}