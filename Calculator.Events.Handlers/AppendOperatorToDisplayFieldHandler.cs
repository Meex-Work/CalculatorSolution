using Calculator.Events.Handlers.Interfaces;
using Calculator.Queries;
using Calculator.Queries.Handlers.Interfaces;

namespace Calculator.Events.Handlers;

public sealed class AppendOperatorToDisplayFieldHandler(
    IQueryHandler<FirstNumberQuery> handler
) : IEventHandler<ClickedOperatorButtonEvent>
{
    public ClickedOperatorButtonEvent Handle(ClickedOperatorButtonEvent @event) =>
        @event with
        {
            OperationLabelText = $"{handler.Query().Value} {@event.Operator}"
        };
}