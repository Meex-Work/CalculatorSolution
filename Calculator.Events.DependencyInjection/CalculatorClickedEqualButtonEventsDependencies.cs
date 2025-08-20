using Calculator.Commands;
using Calculator.Commands.Handlers.Interfaces;
using Calculator.Events.Handlers;
using Calculator.Events.Handlers.Adapters;
using Calculator.Events.Handlers.Composites;
using Calculator.Events.Handlers.Interfaces;
using Calculator.Queries;
using Calculator.Queries.Handlers.Interfaces;
using Calculator.Services.Inputs;
using Calculator.Services.Interfaces;
using Calculator.Services.Results;
using Calculator.States.Contexts;
using Calculator.States.Contexts.Interfaces;
using Calculator.States.DependencyInjection.Extensions;
using Calculator.States.Interfaces;
using DependencyInjection.Interfaces;
using DependencyInjection.Strategies.Interfaces;

namespace Calculator.Events.DependencyInjection;

internal static class CalculatorClickedEqualButtonEventsDependencies
{
    internal static IDependencyRegistrarOrBuild RegisterClickedEqualButtonEvent(this IDependencyRegistrar registrar)
        => registrar
            .RegisterStrategy<
                IStrategy<IState, IStateEventHandler<ClickedEqualButtonEvent>>,
                IState,
                IStateEventHandler<ClickedEqualButtonEvent>
            >((provider, builder) => builder
                .Transition(
                    from: State.Start,
                    sequence: StartEventHandler(provider), to: State.Start)
                .Transition(
                    from: State.FirstNumber,
                    sequence: FirstNumberEventHandler(provider), to: State.FirstNumber)
                .Transition(
                    from: State.FirstNumberDecimal,
                    sequence: FirstNumberDecimalEventHandler(provider), to: State.FirstNumberDecimal)
                .Transition(
                    from: State.Operator,
                    sequence: OperatorEventHandler(provider), to: State.Result)
                .Transition(
                    from: State.SecondNumber,
                    sequence: SecondNumberEventHandler(provider), to: State.Result)
                .Transition(
                    from: State.SecondNumberDecimal,
                    sequence: SecondNumberDecimalEventHandler(provider), to: State.Result)
                .Transition(
                    from: State.Result,
                    sequence: ResultEventHandler(provider), to: State.Result)
            )
            .RegisterAdapter<
                IStrategy<IState, IStateEventHandler<ClickedEqualButtonEvent>>,
                IEventHandler<ClickedEqualButtonEvent>
            >((provider, service) =>
                StateEventHandlerStrategyAdapter.Adapt(
                    provider.Resolve<IStateManager>(),
                    service
                )
            );

    private static IEventHandler<ClickedEqualButtonEvent> StartEventHandler(
        IDependencyProvider _
    ) => NoActionEventHandler.Build<ClickedEqualButtonEvent>();

    private static IEventHandler<ClickedEqualButtonEvent> FirstNumberEventHandler(
        IDependencyProvider _
    ) => NoActionEventHandler.Build<ClickedEqualButtonEvent>();


    private static IEventHandler<ClickedEqualButtonEvent> FirstNumberDecimalEventHandler(
        IDependencyProvider _
    ) => NoActionEventHandler.Build<ClickedEqualButtonEvent>();

    private static IEventHandler<ClickedEqualButtonEvent> OperatorEventHandler(
        IDependencyProvider provider
    ) => EventHandlerComposite.Sequence(
        UpdateSecondNumberHandler.Build<ClickedEqualButtonEvent>(
            provider.Resolve<ICommandHandler<UpdateSecondNumberCommand>>()
        ),
        CalculateNumbersHandler.Build<ClickedEqualButtonEvent>(
            provider.Resolve<IQueryHandler<FirstNumberQuery>>(),
            provider.Resolve<IQueryHandler<SecondNumberQuery>>(),
            provider.Resolve<IService<CalculationInput, CalculationResult>>()
        ),
        AppendSecondNumberToDisplayFieldHandler.Build<ClickedEqualButtonEvent>(
            provider.Resolve<IQueryHandler<SecondNumberQuery>>()
        )
    );

    private static IEventHandler<ClickedEqualButtonEvent> SecondNumberEventHandler(
        IDependencyProvider provider
    ) => EventHandlerComposite.Sequence(
        UpdateSecondNumberHandler.Build<ClickedEqualButtonEvent>(
            provider.Resolve<ICommandHandler<UpdateSecondNumberCommand>>()
        ),
        CalculateNumbersHandler.Build<ClickedEqualButtonEvent>(
            provider.Resolve<IQueryHandler<FirstNumberQuery>>(),
            provider.Resolve<IQueryHandler<SecondNumberQuery>>(),
            provider.Resolve<IService<CalculationInput, CalculationResult>>()
        ),
        AppendSecondNumberToDisplayFieldHandler.Build<ClickedEqualButtonEvent>(
            provider.Resolve<IQueryHandler<SecondNumberQuery>>()
        )
        // todo: update first number?
    );

    private static IEventHandler<ClickedEqualButtonEvent> SecondNumberDecimalEventHandler(
        IDependencyProvider _
    ) => NoActionEventHandler.Build<ClickedEqualButtonEvent>();

    private static IEventHandler<ClickedEqualButtonEvent> ResultEventHandler(
        IDependencyProvider provider
    ) => EventHandlerComposite.Sequence(
        UpdateSecondNumberHandler.Build<ClickedEqualButtonEvent>(
            provider.Resolve<ICommandHandler<UpdateSecondNumberCommand>>()
        ),
        CalculateNumbersHandler.Build<ClickedEqualButtonEvent>(
            provider.Resolve<IQueryHandler<FirstNumberQuery>>(),
            provider.Resolve<IQueryHandler<SecondNumberQuery>>(),
            provider.Resolve<IService<CalculationInput, CalculationResult>>()
        ),
        AppendSecondNumberToDisplayFieldHandler.Build<ClickedEqualButtonEvent>(
            provider.Resolve<IQueryHandler<SecondNumberQuery>>()
        )
        // todo: update first number?
    );
}