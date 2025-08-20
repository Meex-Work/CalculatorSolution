using Calculator.Commands;
using Calculator.Commands.Handlers.Interfaces;
using Calculator.Events.Handlers;
using Calculator.Events.Handlers.Adapters;
using Calculator.Events.Handlers.Interfaces;
using Calculator.Queries;
using Calculator.Queries.Handlers.Interfaces;
using Calculator.States.Contexts;
using Calculator.States.Contexts.Interfaces;
using Calculator.States.DependencyInjection.Extensions;
using Calculator.States.Interfaces;
using DependencyInjection.Interfaces;
using DependencyInjection.Strategies.Interfaces;

namespace Calculator.Events.DependencyInjection;

internal static class CalculatorClickedOperatorButtonEventsDependencies
{
    internal static IDependencyRegistrarOrBuild RegisterClickedOperatorButtonEvent(this IDependencyRegistrar registrar)
        => registrar
            .RegisterStrategy<
                IStrategy<IState, IStateEventHandler<ClickedOperatorButtonEvent>>,
                IState,
                IStateEventHandler<ClickedOperatorButtonEvent>
            >((provider, builder) => builder
                .Transition(
                    from: State.Start,
                    sequence:
                    [
                        UpdateFirstNumberHandler.Build<ClickedOperatorButtonEvent>(
                            provider.Resolve<ICommandHandler<UpdateFirstNumberCommand>>()
                        ),
                        new UpdateOperatorHandler(provider.Resolve<ICommandHandler<UpdateOperatorCommand>>()),
                        new AppendOperatorToDisplayFieldHandler(provider.Resolve<IQueryHandler<FirstNumberQuery>>()),
                        ResetInputFieldHandler.Build<ClickedOperatorButtonEvent>()
                    ],
                    to: State.Operator
                )
                .Transition(
                    from: State.FirstNumber,
                    sequence:
                    [
                        UpdateFirstNumberHandler.Build<ClickedOperatorButtonEvent>(
                            provider.Resolve<ICommandHandler<UpdateFirstNumberCommand>>()
                        ),
                        new UpdateOperatorHandler(provider.Resolve<ICommandHandler<UpdateOperatorCommand>>()),
                        new AppendOperatorToDisplayFieldHandler(provider.Resolve<IQueryHandler<FirstNumberQuery>>()),
                        ResetInputFieldHandler.Build<ClickedOperatorButtonEvent>()
                    ],
                    to: State.Operator
                )
                .Transition(
                    from: State.FirstNumberDecimal,
                    sequence:
                    [
                        UpdateFirstNumberHandler.Build<ClickedOperatorButtonEvent>(
                            provider.Resolve<ICommandHandler<UpdateFirstNumberCommand>>()
                        ),
                        new UpdateOperatorHandler(provider.Resolve<ICommandHandler<UpdateOperatorCommand>>()),
                        new AppendOperatorToDisplayFieldHandler(provider.Resolve<IQueryHandler<FirstNumberQuery>>()),
                        ResetInputFieldHandler.Build<ClickedOperatorButtonEvent>()
                    ],
                    to: State.Operator
                )
                .Transition(
                    from: State.Operator,
                    sequence:
                    [
                        new UpdateOperatorHandler(provider.Resolve<ICommandHandler<UpdateOperatorCommand>>())
                    ],
                    to: State.Operator
                )
                .Transition(
                    from: State.SecondNumber,
                    sequence:
                    [
                        NoActionEventHandler.Build<ClickedOperatorButtonEvent>()
                    ],
                    to: State.SecondNumber
                )
                .Transition(
                    from: State.SecondNumberDecimal,
                    sequence:
                    [
                        NoActionEventHandler.Build<ClickedOperatorButtonEvent>()
                    ],
                    to: State.SecondNumberDecimal
                )
                .Transition(
                    from: State.Result,
                    sequence:
                    [
                        UpdateFirstNumberHandler.Build<ClickedOperatorButtonEvent>(
                            provider.Resolve<ICommandHandler<UpdateFirstNumberCommand>>()
                        ),
                        new UpdateOperatorHandler(provider.Resolve<ICommandHandler<UpdateOperatorCommand>>()),
                        new AppendOperatorToDisplayFieldHandler(provider.Resolve<IQueryHandler<FirstNumberQuery>>()),
                        ResetInputFieldHandler.Build<ClickedOperatorButtonEvent>()
                    ],
                    to: State.Operator
                )
            )
            .RegisterAdapter<
                IStrategy<IState, IStateEventHandler<ClickedOperatorButtonEvent>>,
                IEventHandler<ClickedOperatorButtonEvent>
            >((provider, service) =>
                StateEventHandlerStrategyAdapter.Adapt(
                    provider.Resolve<IStateManager>(),
                    service
                )
            );
}