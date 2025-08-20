using Calculator.Services.Adapters;
using Calculator.Services.Contexts;
using Calculator.Services.Contexts.Interfaces;
using Calculator.Services.Decorators;
using Calculator.Services.Inputs;
using Calculator.Services.Interfaces;
using Calculator.Services.Results;
using Calculator.States.Interfaces;
using DependencyInjection.Interfaces;
using DependencyInjection.Strategies.Interfaces;

namespace Calculator.Services.DependencyInjection;

public static class CalculatorServicesDependencies
{
    public static IDependencyRegistrarOrBuild RegisterServices(this IDependencyRegistrar registrar)
        => registrar
            .RegisterStrategy<
                IStrategy<IOperation, IService<CalculationInput, CalculationResult>>,
                IOperation,
                IService<CalculationInput, CalculationResult>
            >(builder => builder
                .Strategy(new CalculationAddService()).For(Operation.Add)
                .Strategy(new CalculationSubtractService()).For(Operation.Subtract)
                .Strategy(new CalculationMultiplyService()).For(Operation.Multiply)
                .Strategy(
                    CalculationServicePreValidationDecorator.SecondNumberIsNotNull(
                        new CalculationDivideService()
                    )
                ).For(Operation.Divide)
            )
            .RegisterAdapter<
                IStrategy<IOperation, IService<CalculationInput, CalculationResult>>,
                IService<CalculationInput, CalculationResult>
            >((provider, service) => OperationServiceStrategyAdapter.Adapt(
                    provider.Resolve<IStateManager>(),
                    provider.Resolve<IOperationListValues>(),
                    service
                )
            )
            .Register<IOperationListNames>(_ => Operation.Names)
            .Register<IOperationListValues>(_ => Operation.Values);
}