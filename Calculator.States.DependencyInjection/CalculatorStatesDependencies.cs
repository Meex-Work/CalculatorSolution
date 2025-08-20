using Calculator.States.Contexts;
using Calculator.States.Contexts.Interfaces;
using Calculator.States.Interfaces;
using Calculator.States.Manager;
using DependencyInjection.Interfaces;

namespace Calculator.States.DependencyInjection;

public static class CalculatorStatesDependencies
{
    public static IDependencyRegistrarOrBuild RegisterStates(this IDependencyRegistrar registrar) => registrar
        .Register<IStateList>(_ => State.List)
        .RegisterSingleton<IStateManager>(provider =>
            new CalculatorStateManagerSingleton(
                provider.Resolve<IStateList>()
            )
        );
}