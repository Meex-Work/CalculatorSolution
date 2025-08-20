using Calculator.Events.Handlers;
using Calculator.Events.Handlers.Adapters;
using Calculator.Events.Handlers.Interfaces;
using Calculator.States.Contexts;
using Calculator.States.Contexts.Interfaces;
using Calculator.States.DependencyInjection.Extensions;
using Calculator.States.Interfaces;
using DependencyInjection.Interfaces;
using DependencyInjection.Strategies.Interfaces;

namespace Calculator.Events.DependencyInjection;

internal static class CalculatorClickedNumberButtonEventsDependencies
{
    internal static IDependencyRegistrarOrBuild RegisterClickedNumberButtonEvent(this IDependencyRegistrar registrar)
        => registrar
            .RegisterStrategy<
                IStrategy<IState, IStateEventHandler<ClickedNumberButtonEvent>>,
                IState,
                IStateEventHandler<ClickedNumberButtonEvent>
            >((provider, builder) => builder
                .Choice(
                    from: State.Start,
                    predicate: IsZero,
                    @true: Tuple.Create(StartEventTrueHandler(provider), State.Start),
                    @false: Tuple.Create(StartEventFalseHandler(provider), State.FirstNumber)
                )
                .Transition(
                    from: State.FirstNumber,
                    sequence: FirstNumberEventHandler(provider),
                    to: State.FirstNumber
                )
                .Transition(
                    from: State.FirstNumberDecimal,
                    sequence: FirstNumberDecimalEventHandler(provider),
                    to: State.FirstNumberDecimal
                )
                .Choice(
                    from: State.Operator,
                    predicate: IsZero,
                    @true: Tuple.Create(OperatorEventTrueHandler(provider), State.Operator),
                    @false: Tuple.Create(OperatorEventFalseHandler(provider), State.SecondNumber)
                )
                .Transition(
                    from: State.SecondNumber,
                    sequence: SecondNumberEventHandler(provider),
                    to: State.SecondNumber
                )
                .Transition(
                    from: State.SecondNumberDecimal,
                    sequence: SecondNumberDecimalEventHandler(provider),
                    to: State.SecondNumberDecimal
                )
                .Transition(
                    from: State.Result,
                    sequence: ResultEventHandler(provider),
                    to: State.FirstNumber
                )
            )
            .RegisterAdapter<
                IStrategy<IState, IStateEventHandler<ClickedNumberButtonEvent>>,
                IEventHandler<ClickedNumberButtonEvent>
            >((provider, service) =>
                StateEventHandlerStrategyAdapter.Adapt(
                    provider.Resolve<IStateManager>(),
                    service
                )
            );

    private static bool IsZero(ClickedNumberButtonEvent @event) => @event.Number == "0";

    private static IEventHandler<ClickedNumberButtonEvent> StartEventTrueHandler(
        IDependencyProvider _
    ) => NoActionEventHandler.Build<ClickedNumberButtonEvent>();

    private static IEventHandler<ClickedNumberButtonEvent> StartEventFalseHandler(
        IDependencyProvider _
    ) => new ReplaceInputFieldWithNumberHandler();

    private static IEventHandler<ClickedNumberButtonEvent> FirstNumberEventHandler(
        IDependencyProvider _
    ) => new AppendNumberToInputFieldHandler();

    private static IEventHandler<ClickedNumberButtonEvent> FirstNumberDecimalEventHandler(
        IDependencyProvider _
    ) => new AppendNumberToInputFieldHandler();

    private static IEventHandler<ClickedNumberButtonEvent> OperatorEventTrueHandler(
        IDependencyProvider _
    ) => NoActionEventHandler.Build<ClickedNumberButtonEvent>();

    private static IEventHandler<ClickedNumberButtonEvent> OperatorEventFalseHandler(
        IDependencyProvider _
    ) => new ReplaceInputFieldWithNumberHandler();

    private static IEventHandler<ClickedNumberButtonEvent> SecondNumberEventHandler(
        IDependencyProvider _
    ) => new AppendNumberToInputFieldHandler();

    private static IEventHandler<ClickedNumberButtonEvent> SecondNumberDecimalEventHandler(
        IDependencyProvider _
    ) => new AppendNumberToInputFieldHandler();

    private static IEventHandler<ClickedNumberButtonEvent> ResultEventHandler(
        IDependencyProvider _
    ) => new ReplaceInputFieldWithNumberHandler();
}