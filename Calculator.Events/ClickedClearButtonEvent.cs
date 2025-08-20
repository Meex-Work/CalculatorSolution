using Calculator.Events.Abstracts;

namespace Calculator.Events;

public sealed record ClickedClearButtonEvent(
    string InputFieldText,
    string OperationLabelText
) : CalculatorEvent(
    InputFieldText,
    OperationLabelText
);