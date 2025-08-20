using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Composites;
using Calculator.Events.Handlers.Interfaces;
using Calculator.States.Contexts.Interfaces;
using Calculator.States.Handlers;
using Calculator.States.Interfaces;
using DependencyInjection.Strategies.Interfaces;

namespace Calculator.States.DependencyInjection.Extensions;

public static class Extensions
{
    public static IStrategyListBuilderEntryOrBuild<IState, IStateEventHandler<TTarget>> Transition<TTarget>(
        this IStrategyListBuilderEntry<IState, IStateEventHandler<TTarget>> builder,
        IState from,
        IStateEventHandlerTransitionBuilder<TTarget> sequence,
        IState to
    ) => builder
        .Strategy(sequence.TransitionTo(to))
        .For(from);

    public static IStrategyListBuilderEntryOrBuild<IState, IStateEventHandler<TTarget>> Choice<TTarget>(
        this IStrategyListBuilderEntry<IState, IStateEventHandler<TTarget>> builder,
        IState from,
        Predicate<TTarget> predicate,
        IStateEventHandlerTransitionBuilder<TTarget> trueHandler,
        IState toTrue,
        IStateEventHandlerTransitionBuilder<TTarget> falseHandler,
        IState toFalse
    ) => builder
        .Strategy(
            StateChoiceEventHandler.Build(
                predicate,
                trueHandler.TransitionTo(toTrue),
                falseHandler.TransitionTo(toFalse)
            )
        )
        .For(from);

    public static IStrategyListBuilderEntryOrBuild<IState, IStateEventHandler<TTarget>> Transition<TTarget>(
        this IStrategyListBuilderEntry<IState, IStateEventHandler<TTarget>> builder,
        IState from,
        IEventHandler<TTarget> sequence,
        IState to
    ) => builder.Transition(
        from,
        StateEventHandler.Build(sequence),
        to
    );

    public static IStrategyListBuilderEntryOrBuild<IState, IStateEventHandler<TTarget>> Transition<TTarget>(
        this IStrategyListBuilderEntry<IState, IStateEventHandler<TTarget>> builder,
        IState from,
        IEventHandler<TTarget>[] sequence,
        IState to
    )
        where TTarget : CalculatorEvent
        => builder.Transition(
            from,
            StateEventHandler.Build(EventHandlerComposite.Sequence(sequence)),
            to
        );


    public static IStrategyListBuilderEntryOrBuild<IState, IStateEventHandler<TTarget>> Choice<TTarget>(
        this IStrategyListBuilderEntry<IState, IStateEventHandler<TTarget>> builder,
        IState from,
        Predicate<TTarget> predicate,
        Tuple<IEventHandler<TTarget>, IState> @true,
        Tuple<IEventHandler<TTarget>, IState> @false
    ) => builder.Choice(
        from: from,
        predicate: predicate,
        trueHandler: StateEventHandler.Build(@true.Item1),
        toTrue: @true.Item2,
        falseHandler: StateEventHandler.Build(@false.Item1),
        toFalse: @false.Item2
    );

    public static IStrategyListBuilderEntryOrBuild<IState, IStateEventHandler<TTarget>> Choice<TTarget>(
        this IStrategyListBuilderEntry<IState, IStateEventHandler<TTarget>> builder,
        IState from,
        Predicate<TTarget> predicate,
        IEventHandler<TTarget>[] trueSequence,
        IState toTrue,
        IEventHandler<TTarget>[] falseSequence,
        IState toFalse
    )
        where TTarget : CalculatorEvent
        => builder.Choice(
            from,
            predicate,
            StateEventHandler.Build(EventHandlerComposite.Sequence(trueSequence)),
            toTrue,
            StateEventHandler.Build(EventHandlerComposite.Sequence(falseSequence)),
            toFalse
        );
}