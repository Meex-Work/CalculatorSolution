using Calculator.Events;
using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Interfaces;
using Calculator.Services.Contexts;
using Tests.Unit.Interfaces;

namespace Tests.Unit.Builder;

internal sealed class TestArrangeBuilder<TEvent>(
    ICalculatorEventHandlerFacade facade,
    TEvent startEvent
) : ITestArrangeBuilder<TEvent>
    where TEvent : CalculatorEvent
{
    private TEvent _event = startEvent;
    public TEvent SetToStart() => _event;

    public TEvent SetToFirstNumber()
    {
        var @event = facade.HandleNumberButtonEvent(new ClickedNumberButtonEvent(
                "1",
                _event.InputFieldText,
                _event.OperationLabelText
            )
        );
        return _event with
        {
            InputFieldText = @event.InputFieldText,
            OperationLabelText = @event.OperationLabelText
        };
    }

    public TEvent SetToFirstNumberDecimal()
    {
        var @event = facade.HandleDecimalButtonEvent(new ClickedDecimalButtonEvent(
                _event.InputFieldText,
                _event.OperationLabelText
            )
        );
        return _event with
        {
            InputFieldText = @event.InputFieldText,
            OperationLabelText = @event.OperationLabelText
        };
    }

    public TEvent SetToOperator()
    {
        var @event = facade.HandleOperatorButtonEvent(new ClickedOperatorButtonEvent(
            Operation.Add.Value,
            _event.InputFieldText,
            _event.OperationLabelText)
        );
        return _event with
        {
            InputFieldText = @event.InputFieldText,
            OperationLabelText = @event.OperationLabelText
        };
    }

    public TEvent SetToSecondNumber()
    {
        _event = SetToFirstNumber();
        _event = SetToOperator();
        var @event = facade.HandleNumberButtonEvent(new ClickedNumberButtonEvent(
                "2",
                _event.InputFieldText,
                _event.OperationLabelText
            )
        );
        return _event with
        {
            InputFieldText = @event.InputFieldText,
            OperationLabelText = @event.OperationLabelText
        };
    }

    public TEvent SetToSecondNumberDecimal()
    {
        _event = SetToFirstNumber();
        _event = SetToOperator();
        _event = SetToSecondNumber();
        var @event = facade.HandleDecimalButtonEvent(new ClickedDecimalButtonEvent(
            _event.InputFieldText,
            _event.OperationLabelText)
        );
        return _event with
        {
            InputFieldText = @event.InputFieldText,
            OperationLabelText = @event.OperationLabelText
        };
    }

    public TEvent SetToResult()
    {
        _event = SetToFirstNumber();
        _event = SetToOperator();
        _event = SetToSecondNumber();
        var @event = facade.HandleEqualButtonEvent(new ClickedEqualButtonEvent(
                _event.InputFieldText,
                _event.OperationLabelText
            )
        );
        return _event with
        {
            InputFieldText = @event.InputFieldText,
            OperationLabelText = @event.OperationLabelText
        };
    }
}