using Calculator.Events.Handlers.Interfaces;

namespace Calculator.Events.Handlers;

public sealed class AppendNumberToInputFieldHandler : IEventHandler<ClickedNumberButtonEvent>
{
    public ClickedNumberButtonEvent Handle(ClickedNumberButtonEvent @event) =>
        @event with
        {
            InputFieldText = @event.InputFieldText + @event.Number
        };
}