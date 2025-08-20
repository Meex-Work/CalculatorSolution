using Calculator.Events;
using Calculator.Services.Contexts;
using Tests.Unit.Builder;
using Tests.Unit.Interfaces;

namespace Tests.Unit;

[TestFixture]
[Parallelizable(ParallelScope.Fixtures)]
public sealed class CalculatorFromClickedOperatorButtonEventTests
{
    private readonly ITestBuilder<ClickedOperatorButtonEvent> _testBuilder =
        CalculatorFormEventTestBuilder.Create(
            new ClickedOperatorButtonEvent(Operation.Add.Value, "0", string.Empty)
        );

    [Test]
    [Parallelizable(ParallelScope.Self)]
    [TestCase("+")]
    [TestCase("-")]
    [TestCase("×")]
    [TestCase("÷")]
    public void Pressing_an_operator_button_when_there_is_zero_in_the_input_does_not_change_the_input_field(
        string operation
    )
    {
        _testBuilder
            .Arrange(state => state.SetToStart)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedOperatorButtonEvent(
                    operation,
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertInputFieldTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    [TestCase("+")]
    [TestCase("-")]
    [TestCase("×")]
    [TestCase("÷")]
    public void
        Pressing_an_operator_button_when_there_is_zero_in_the_input_puts_zero_and_the_operation_in_the_operation_label(
            string operation
        )
    {
        _testBuilder
            .Arrange(state => state.SetToStart)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedOperatorButtonEvent(
                    operation,
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertOperationLabelText(_ => "0 " + operation);
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    [TestCase("+")]
    [TestCase("-")]
    [TestCase("×")]
    [TestCase("÷")]
    public void Pressing_an_operator_button_when_there_is_a_non_zero_number_in_the_input_resets_the_input_field(
        string operation
    )
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumber)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedOperatorButtonEvent(
                    operation,
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertOperationLabelTextReset();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    [TestCase("+")]
    [TestCase("-")]
    [TestCase("×")]
    [TestCase("÷")]
    public void
        Pressing_an_operator_button_when_there_is_a_non_zero_number_in_the_input_puts_the_number_and_the_operation_in_the_operation_label(
            string operation
        )
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumber)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedOperatorButtonEvent(
                    operation,
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertOperationLabelText(start => $"{start.InputFieldText} {operation}");
    }
}