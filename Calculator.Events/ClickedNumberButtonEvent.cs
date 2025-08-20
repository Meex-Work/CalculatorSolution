using Calculator.Events.Abstracts;

namespace Calculator.Events;

public sealed record ClickedNumberButtonEvent(
    string Number,
    string InputFieldText,
    string OperationLabelText
) : CalculatorEvent(
    InputFieldText,
    OperationLabelText
);