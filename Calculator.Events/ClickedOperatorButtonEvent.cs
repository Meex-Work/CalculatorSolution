using Calculator.Events.Abstracts;

namespace Calculator.Events;

public sealed record ClickedOperatorButtonEvent(
    string Operator,
    string InputFieldText,
    string OperationLabelText
) : CalculatorEvent(
    InputFieldText,
    OperationLabelText
);