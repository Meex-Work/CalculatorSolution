using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Interfaces;
using Calculator.Queries;
using Calculator.Queries.Handlers.Interfaces;

namespace Calculator.Events.Handlers;

public static class AppendSecondNumberToDisplayFieldHandler
{
    public static IEventHandler<TEvent> Build<TEvent>(
        IQueryHandler<SecondNumberQuery> handler
    ) where TEvent : CalculatorEvent
        => new AppendSecondNumberToDisplayFieldHandler<TEvent>(handler);
}

internal sealed class AppendSecondNumberToDisplayFieldHandler<TEvent>(
    IQueryHandler<SecondNumberQuery> handler
) : IEventHandler<TEvent>
    where TEvent : CalculatorEvent
{
    public TEvent Handle(TEvent @event) =>
        @event with
        {
            OperationLabelText = $"{@event.OperationLabelText} {handler.Query().Value}"
        };
}