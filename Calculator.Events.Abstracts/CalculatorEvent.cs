namespace Calculator.Events.Abstracts;

public abstract record CalculatorEvent(
    string InputFieldText,
    string OperationLabelText
);