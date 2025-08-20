using Calculator.Events;
using Tests.Unit.Builder;
using Tests.Unit.Interfaces;

namespace Tests.Unit;

[TestFixture]
[Parallelizable(ParallelScope.Fixtures)]
public sealed class CalculatorFormClickedEqualButtonEventTests
{
    private readonly ITestBuilder<ClickedEqualButtonEvent> _testBuilder =
        CalculatorFormEventTestBuilder.Create(
            new ClickedEqualButtonEvent("0", string.Empty)
        );

    private static ClickedEqualButtonEvent CreateEvent(
        string currentInput,
        string currentOperationLabel
    ) => new(
        currentInput,
        currentOperationLabel
    );

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void Pressing_the_equal_button_when_there_is_only_zero_in_the_input_field_does_not_change_the_input_field()
    {
        _testBuilder
            .Arrange(state => state.SetToStart)
            .Act(CreateEvent)
            .AssertInputFieldTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_equal_button_when_there_is_only_zero_in_the_input_field_does_not_change_the_operation_label()
    {
        _testBuilder
            .Arrange(state => state.SetToStart)
            .Act(CreateEvent)
            .AssertOperationLabelTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void Pressing_the_equal_button_when_there_is_a_number_in_the_input_field_does_not_change_the_input_field()
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumber)
            .Act(CreateEvent)
            .AssertInputFieldTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_equal_button_when_there_is_a_number_in_the_input_field_does_not_change_the_operation_label()
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumber)
            .Act(CreateEvent)
            .AssertOperationLabelTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_equal_button_when_there_is_a_number_with_decimal_in_the_input_field_does_not_change_the_input_field()
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumberDecimal)
            .Act(CreateEvent)
            .AssertInputFieldTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_equal_button_when_there_is_a_number_with_decimal_in_the_input_field_does_not_change_the_operation_label()
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumberDecimal)
            .Act(CreateEvent)
            .AssertOperationLabelTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_equal_button_directly_after_an_operator_was_set_calculates_the_result_and_puts_it_in_the_input_field()
    {
        _testBuilder
            .Arrange(state => state.SetToOperator)
            .Act(CreateEvent)
            .AssertInputFieldText(start => $"{double.Parse(start.OperationLabelText[0].ToString()) + 0}");
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_equal_button_directly_after_an_operator_was_set_appends_the_text_in_the_input_field_to_the_operation_label()
    {
        _testBuilder
            .Arrange(state => state.SetToOperator)
            .Act(CreateEvent)
            .AssertOperationLabelText(start => $"{start.OperationLabelText} 0");
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_equal_button_when_there_is_a_second_number_in_the_input_field_calculates_the_result_and_puts_it_in_the_input_field()
    {
        _testBuilder
            .Arrange(state => state.SetToSecondNumber)
            .Act(CreateEvent)
            .AssertInputFieldText(start =>
                $"{double.Parse(start.OperationLabelText[0].ToString()) + double.Parse(start.InputFieldText)}"
            );
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_equal_button_when_there_is_a_second_number_in_the_input_field_appends_the_input_field_to_the_operation_label()
    {
        _testBuilder
            .Arrange(state => state.SetToSecondNumber)
            .Act(CreateEvent)
            .AssertOperationLabelText(start => $"{start.OperationLabelText} {start.InputFieldText}");
    }
}