using Calculator.Events;
using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Interfaces;

namespace Calculator;

public partial class CalculatorForm : Form
{
    private readonly ICalculatorEventHandlerFacade _eventHandler;

    public static CalculatorForm Create(
        ICalculatorEventHandlerFacade eventHandler
    ) => new(
        eventHandler
    );

    private CalculatorForm(
        ICalculatorEventHandlerFacade eventHandler
    )
    {
        _eventHandler = eventHandler;
        InitializeComponent();
    }

    private void btnDecimal_Click(object sender, EventArgs e)
    {
        var @event = _eventHandler
            .HandleDecimalButtonEvent(
                new ClickedDecimalButtonEvent(
                    txtDisplay.Text,
                    lblOperation.Text
                )
            );
        
        UpdateDisplay(@event);
    }

    private void btnNumber_Click(object sender, EventArgs e)
    {
        var button = (Button)sender;

        var @event = _eventHandler
            .HandleNumberButtonEvent(
                new ClickedNumberButtonEvent(
                    button.Text,
                    txtDisplay.Text,
                    lblOperation.Text
                )
            );

        UpdateDisplay(@event);
    }

    private void btnOperator_Click(object sender, EventArgs e)
    {
        var button = (Button)sender;

        var @event = _eventHandler
            .HandleOperatorButtonEvent(
                new ClickedOperatorButtonEvent(
                    button.Text,
                    txtDisplay.Text,
                    lblOperation.Text
                )
            );

        UpdateDisplay(@event);
    }

    private void btnEquals_Click(object sender, EventArgs e)
    {
        var @event = _eventHandler
            .HandleEqualButtonEvent(
                new ClickedEqualButtonEvent(
                    txtDisplay.Text,
                    lblOperation.Text
                )
            );

        UpdateDisplay(@event);
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        var @event = _eventHandler
            .HandleClearButtonEvent(
                new ClickedClearButtonEvent(
                    txtDisplay.Text,
                    lblOperation.Text
                )
            );

        UpdateDisplay(@event);
    }

    private void btnBackspace_Click(object sender, EventArgs e)
    {
        var @event = _eventHandler
            .HandleBackspaceButtonEvent(
                new ClickedBackspaceButtonEvent(
                    txtDisplay.Text,
                    lblOperation.Text
                )
            );

        UpdateDisplay(@event);
    }

    private void UpdateDisplay(CalculatorEvent result) =>
        UpdateDisplay(
            result.InputFieldText,
            result.OperationLabelText
        );

    private void UpdateDisplay(
        string inputFieldText,
        string operationLabelText
    )
    {
        txtDisplay.Text = inputFieldText;
        lblOperation.Text = operationLabelText;
    }
}