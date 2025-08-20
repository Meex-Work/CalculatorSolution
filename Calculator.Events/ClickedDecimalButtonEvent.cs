using Calculator.Events.Abstracts;

namespace Calculator.Events;

public sealed record ClickedDecimalButtonEvent(
    string InputFieldText,
    string OperationLabelText
) : CalculatorEvent(
    InputFieldText,
    OperationLabelText
);