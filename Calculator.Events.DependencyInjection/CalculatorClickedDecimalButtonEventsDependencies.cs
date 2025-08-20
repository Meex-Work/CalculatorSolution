using Calculator.Events.Handlers;
using Calculator.Events.Handlers.Adapters;
using Calculator.Events.Handlers.Composites;
using Calculator.Events.Handlers.Interfaces;
using Calculator.States.Contexts;
using Calculator.States.Contexts.Interfaces;
using Calculator.States.DependencyInjection.Extensions;
using Calculator.States.Interfaces;
using DependencyInjection.Interfaces;
using DependencyInjection.Strategies.Interfaces;

namespace Calculator.Events.DependencyInjection;

internal static class CalculatorClickedDecimalButtonEventsDependencies
{
    internal static IDependencyRegistrarOrBuild RegisterClickedDecimalButtonEvent(this IDependencyRegistrar registrar)
        => registrar
            .RegisterStrategy<
                IStrategy<IState, IStateEventHandler<ClickedDecimalButtonEvent>>,
                IState,
                IStateEventHandler<ClickedDecimalButtonEvent>
            >((provider, builder) => builder
                .Transition(
                    from: State.Start,
                    sequence: StartEventHandler(provider),
                    to: State.FirstNumberDecimal
                )
                .Transition(
                    from: State.FirstNumber,
                    sequence: FirstNumberEventHandler(provider),
                    to: State.FirstNumberDecimal
                )
                .Transition(
                    from: State.FirstNumberDecimal,
                    sequence: FirstNumberDecimalEventHandler(provider),
                    to: State.FirstNumberDecimal
                )
                .Transition(
                    from: State.Operator,
                    sequence: OperatorEventHandler(provider),
                    to: State.Operator
                )
                .Transition(
                    from: State.SecondNumber,
                    sequence: SecondNumberEventHandler(provider),
                    to: State.SecondNumberDecimal
                )
                .Transition(
                    from: State.SecondNumberDecimal,
                    sequence: SecondNumberDecimalEventHandler(provider),
                    to: State.SecondNumberDecimal
                )
                .Transition(
                    from: State.Result,
                    sequence: ResultEventHandler(provider),
                    to: State.FirstNumberDecimal
                )
            )
            .RegisterAdapter<
                IStrategy<IState, IStateEventHandler<ClickedDecimalButtonEvent>>,
                IEventHandler<ClickedDecimalButtonEvent>
            >((provider, service) =>
                StateEventHandlerStrategyAdapter.Adapt(
                    provider.Resolve<IStateManager>(),
                    service
                )
            );

    private static IEventHandler<ClickedDecimalButtonEvent> StartEventHandler(
        IDependencyProvider _
    ) => AppendDecimalToInputFieldHandler.Build<ClickedDecimalButtonEvent>();

    private static IEventHandler<ClickedDecimalButtonEvent> FirstNumberEventHandler(
        IDependencyProvider _
    ) => AppendDecimalToInputFieldHandler.Build<ClickedDecimalButtonEvent>();

    private static IEventHandler<ClickedDecimalButtonEvent> OperatorEventHandler(
        IDependencyProvider _
    ) => NoActionEventHandler.Build<ClickedDecimalButtonEvent>();

    private static IEventHandler<ClickedDecimalButtonEvent> FirstNumberDecimalEventHandler(
        IDependencyProvider _
    ) => NoActionEventHandler.Build<ClickedDecimalButtonEvent>();

    private static IEventHandler<ClickedDecimalButtonEvent> SecondNumberEventHandler(
        IDependencyProvider _
    ) => AppendDecimalToInputFieldHandler.Build<ClickedDecimalButtonEvent>();

    private static IEventHandler<ClickedDecimalButtonEvent> SecondNumberDecimalEventHandler(
        IDependencyProvider _
    ) => NoActionEventHandler.Build<ClickedDecimalButtonEvent>();

    private static IEventHandler<ClickedDecimalButtonEvent> ResultEventHandler(
        IDependencyProvider _
    ) => EventHandlerComposite.Sequence(
        ResetInputFieldHandler.Build<ClickedDecimalButtonEvent>(),
        AppendDecimalToInputFieldHandler.Build<ClickedDecimalButtonEvent>()
    );
}