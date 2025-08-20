using Calculator.Events.Handlers.Interfaces;

namespace Calculator.Events.Handlers.Facades;

public sealed class CalculatorEventHandlerFacade(
    IEventHandler<ClickedNumberButtonEvent> clickedNumberButtonEventHandler,
    IEventHandler<ClickedDecimalButtonEvent> clickedDecimalButtonEventHandler,
    IEventHandler<ClickedOperatorButtonEvent> clickedOperatorButtonEventHandler,
    IEventHandler<ClickedEqualButtonEvent> clickedEqualButtonEventHandler,
    IEventHandler<ClickedClearButtonEvent> clickedClearButtonEventHandler,
    IEventHandler<ClickedBackspaceButtonEvent> clickedBackspaceButtonEventHandler
) : ICalculatorEventHandlerFacade
{
    public ClickedNumberButtonEvent HandleNumberButtonEvent(ClickedNumberButtonEvent @event) =>
        clickedNumberButtonEventHandler.Handle(@event);

    public ClickedDecimalButtonEvent HandleDecimalButtonEvent(ClickedDecimalButtonEvent @event) =>
        clickedDecimalButtonEventHandler.Handle(@event);

    public ClickedOperatorButtonEvent HandleOperatorButtonEvent(ClickedOperatorButtonEvent @event) =>
        clickedOperatorButtonEventHandler.Handle(@event);

    public ClickedEqualButtonEvent HandleEqualButtonEvent(ClickedEqualButtonEvent @event) =>
        clickedEqualButtonEventHandler.Handle(@event);

    public ClickedClearButtonEvent HandleClearButtonEvent(ClickedClearButtonEvent @event) =>
        clickedClearButtonEventHandler.Handle(@event);

    public ClickedBackspaceButtonEvent HandleBackspaceButtonEvent(ClickedBackspaceButtonEvent @event) =>
        clickedBackspaceButtonEventHandler.Handle(@event);
}