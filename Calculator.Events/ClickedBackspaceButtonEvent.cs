using Calculator.Events.Abstracts;

namespace Calculator.Events;

public sealed record ClickedBackspaceButtonEvent(
    string InputFieldText,
    string OperationLabelText
) : CalculatorEvent(
    InputFieldText,
    OperationLabelText
);