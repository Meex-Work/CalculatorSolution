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

internal static class CalculatorClickedBackspaceButtonEventsDependencies
{
    internal static IDependencyRegistrarOrBuild RegisterClickedBackspaceButtonEvent(this IDependencyRegistrar registrar)
        => registrar
            .RegisterStrategy<
                IStrategy<IState, IStateEventHandler<ClickedBackspaceButtonEvent>>,
                IState,
                IStateEventHandler<ClickedBackspaceButtonEvent>
            >((provider, builder) => builder
                .Transition(
                    from: State.Start,
                    sequence:
                    [
                        NoActionEventHandler.Build<ClickedBackspaceButtonEvent>()
                    ],
                    to: State.Start
                )
                .Choice(
                    from: State.FirstNumber,
                    predicate: OneDigitLeft,
                    trueSequence:
                    [
                        ResetInputFieldHandler.Build<ClickedBackspaceButtonEvent>()
                    ],
                    toTrue: State.Start,
                    falseSequence:
                    [
                        RemoveLastNumberFromInputFieldHandler.Build<ClickedBackspaceButtonEvent>()
                    ],
                    toFalse: State.FirstNumber
                )
                .Choice(
                    from: State.FirstNumberDecimal,
                    predicate: IsDecimalPoint,
                    trueSequence:
                    [
                        RemoveLastNumberFromInputFieldHandler.Build<ClickedBackspaceButtonEvent>()
                    ],
                    toTrue: State.FirstNumber,
                    falseSequence:
                    [
                        RemoveLastNumberFromInputFieldHandler.Build<ClickedBackspaceButtonEvent>()
                    ],
                    toFalse: State.FirstNumberDecimal
                )
                .Transition(
                    from: State.Operator,
                    sequence:
                    [
                        NoActionEventHandler.Build<ClickedBackspaceButtonEvent>()
                    ],
                    to: State.Operator
                )
                .Choice(
                    from: State.SecondNumber,
                    predicate: OneDigitLeft,
                    trueSequence:
                    [
                        ResetInputFieldHandler.Build<ClickedBackspaceButtonEvent>()
                    ],
                    toTrue: State.Operator,
                    falseSequence:
                    [
                        RemoveLastNumberFromInputFieldHandler.Build<ClickedBackspaceButtonEvent>()
                    ],
                    toFalse: State.SecondNumber
                )
                .Choice(
                    from: State.SecondNumberDecimal,
                    predicate: IsDecimalPoint,
                    trueSequence:
                    [
                        RemoveLastNumberFromInputFieldHandler.Build<ClickedBackspaceButtonEvent>()
                    ],
                    toTrue: State.SecondNumber,
                    falseSequence:
                    [
                        RemoveLastNumberFromInputFieldHandler.Build<ClickedBackspaceButtonEvent>()
                    ],
                    toFalse: State.SecondNumberDecimal
                )
                .Transition(
                    from: State.Result,
                    sequence: EventHandlerComposite.ClearAll<ClickedBackspaceButtonEvent>(provider),
                    to: State.Start
                )
            )
            .RegisterAdapter<
                IStrategy<IState, IStateEventHandler<ClickedBackspaceButtonEvent>>,
                IEventHandler<ClickedBackspaceButtonEvent>
            >((provider, service) =>
                StateEventHandlerStrategyAdapter.Adapt(
                    provider.Resolve<IStateManager>(),
                    service
                )
            );

    private static bool IsDecimalPoint(ClickedBackspaceButtonEvent @event) => @event.InputFieldText.EndsWith('.');

    private static bool OneDigitLeft(ClickedBackspaceButtonEvent @event) => @event.InputFieldText.Length <= 1;
}