using Calculator.Events.Abstracts;

namespace Calculator.Events;

public sealed record ClickedEqualButtonEvent(
    string InputFieldText,
    string OperationLabelText
) : CalculatorEvent(
    InputFieldText,
    OperationLabelText
);