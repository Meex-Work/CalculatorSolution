using Calculator.Events.Handlers.Interfaces;

namespace Calculator.Events.Handlers;

public sealed class ReplaceInputFieldWithNumberHandler : IEventHandler<ClickedNumberButtonEvent>
{
    public ClickedNumberButtonEvent Handle(ClickedNumberButtonEvent @event) =>
        @event with
        {
            InputFieldText = @event.Number
        };
}