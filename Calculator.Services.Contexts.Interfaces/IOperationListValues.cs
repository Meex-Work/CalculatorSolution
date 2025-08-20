using Calculator.Utils.Interfaces.Maybe;

namespace Calculator.Services.Contexts.Interfaces;

public interface IOperationListValues
{
    public IOperation FromValue(string value);
    public IOperation FromValue(IMaybe<string> operation);
}