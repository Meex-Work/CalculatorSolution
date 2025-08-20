using Calculator.Commands.Handlers;
using Calculator.Commands.Handlers.Interfaces;
using Calculator.States.Interfaces;
using DependencyInjection.Interfaces;

namespace Calculator.Commands.DependencyInjection;

public static class CalculatorCommandsDependencies
{
    public static IDependencyRegistrarOrBuild RegisterCommands(this IDependencyRegistrar registrar) =>
        registrar
            .Register<ICommandHandler<UpdateFirstNumberCommand>>(provider =>
                new UpdateFirstNumberCommandHandler(provider.Resolve<IStateManager>())
            )
            .Register<ICommandHandler<UpdateSecondNumberCommand>>(provider =>
                new UpdateSecondNumberCommandHandler(provider.Resolve<IStateManager>())
            )
            .Register<ICommandHandler<UpdateOperatorCommand>>(provider =>
                new UpdateOperatorCommandHandler(provider.Resolve<IStateManager>())
            );
}