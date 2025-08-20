using Calculator.Services.Contexts.Interfaces;
using Calculator.Services.Interfaces;
using Calculator.States.Interfaces;
using DependencyInjection.Strategies.Interfaces;

namespace Calculator.Services.Adapters;

public static class OperationServiceStrategyAdapter
{
    public static IService<TInput, TResult> Adapt<TInput, TResult>(
        IStateManager stateManager,
        IOperationListValues operationValues,
        IStrategy<IOperation, IService<TInput, TResult>> strategies
    ) => new OperationServiceStrategyAdapter<TInput, TResult>(
        stateManager,
        operationValues,
        strategies
    );
}

internal sealed class OperationServiceStrategyAdapter<TInput, TResult>(
    IStateManager stateManager,
    IOperationListValues operationValues,
    IStrategy<IOperation, IService<TInput, TResult>> strategies
) : IService<TInput, TResult>
{
    public TResult Execute(TInput input) => strategies
        .Get(operationValues.FromValue(stateManager.Numbers.Operator))
        .Execute(input);
}