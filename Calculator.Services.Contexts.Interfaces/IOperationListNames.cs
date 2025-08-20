using Calculator.Utils.Interfaces.Maybe;

namespace Calculator.Services.Contexts.Interfaces;

public interface IOperationListNames
{
    public IOperation FromName(string operation);
    public IOperation FromName(IMaybe<string> operation);
}