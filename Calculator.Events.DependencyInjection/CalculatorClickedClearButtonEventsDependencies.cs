using Calculator.Events.Handlers.Adapters;
using Calculator.Events.Handlers.Composites;
using Calculator.Events.Handlers.Interfaces;
using Calculator.States.Contexts;
using Calculator.States.Contexts.Interfaces;
using Calculator.States.DependencyInjection.Extensions;
using Calculator.States.Handlers;
using Calculator.States.Interfaces;
using DependencyInjection.Interfaces;
using DependencyInjection.Strategies.Interfaces;

namespace Calculator.Events.DependencyInjection;

internal static class CalculatorClickedClearButtonEventsDependencies
{
    internal static IDependencyRegistrarOrBuild RegisterClickedClearButtonEvent(this IDependencyRegistrar registrar)
        => registrar
            .RegisterStrategy<
                IStrategy<IState, IStateEventHandler<ClickedClearButtonEvent>>,
                IState,
                IStateEventHandler<ClickedClearButtonEvent>
            >((provider, builder) => builder
                .Transition(
                    from: State.Start,
                    sequence: ClearAllEventHandler(provider),
                    to: State.Start
                )
                .Transition(
                    from: State.FirstNumber,
                    sequence: ClearAllEventHandler(provider),
                    to: State.Start
                )
                .Transition(
                    from: State.FirstNumberDecimal,
                    sequence: ClearAllEventHandler(provider),
                    to: State.Start
                )
                .Transition(
                    from: State.Operator,
                    sequence: ClearAllEventHandler(provider),
                    to: State.Start
                )
                .Transition(
                    from: State.SecondNumber,
                    sequence: ClearAllEventHandler(provider),
                    to: State.Start
                )
                .Transition(
                    from: State.SecondNumberDecimal,
                    sequence: ClearAllEventHandler(provider),
                    to: State.Start
                )
                .Transition(
                    from: State.Result,
                    sequence: ClearAllEventHandler(provider),
                    to: State.Start
                )
            )
            .RegisterAdapter<
                IStrategy<IState, IStateEventHandler<ClickedClearButtonEvent>>,
                IEventHandler<ClickedClearButtonEvent>
            >((provider, service) =>
                StateEventHandlerStrategyAdapter.Adapt(
                    provider.Resolve<IStateManager>(),
                    service
                )
            );

    private static IEventHandler<ClickedClearButtonEvent> ClearAllEventHandler(
        IDependencyProvider provider
    ) => EventHandlerComposite.ClearAll<ClickedClearButtonEvent>(provider);
}