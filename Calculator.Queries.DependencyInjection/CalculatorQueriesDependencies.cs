using Calculator.Queries.Handlers;
using Calculator.Queries.Handlers.Interfaces;
using Calculator.States.Interfaces;
using DependencyInjection.Interfaces;

namespace Calculator.Queries.DependencyInjection;

public static class CalculatorQueriesDependencies
{
    public static IDependencyRegistrarOrBuild RegisterQueries(this IDependencyRegistrar registrar) =>
        registrar
            .Register<IQueryHandler<FirstNumberQuery>>(provider =>
                new FirstNumberQueryHandler(provider.Resolve<IStateManager>())
            )
            .Register<IQueryHandler<SecondNumberQuery>>(provider =>
                new SecondNumberQueryHandler(provider.Resolve<IStateManager>())
            )
            .Register<IQueryHandler<OperatorQuery>>(provider =>
                new OperatorQueryHandler(provider.Resolve<IStateManager>())
            );
}