using Calculator.Events;
using Tests.Unit.Builder;
using Tests.Unit.Interfaces;

namespace Tests.Unit;

[TestFixture]
[Parallelizable(ParallelScope.Fixtures)]
public sealed class CalculatorFormClickedBackspaceButtonEventTests
{
    private readonly ITestBuilder<ClickedBackspaceButtonEvent> _testBuilder =
        CalculatorFormEventTestBuilder.Create(
            new ClickedBackspaceButtonEvent("0", string.Empty)
        );

    private static ClickedBackspaceButtonEvent CreateEvent(
        string currentInput,
        string currentOperationLabel
    ) => new(
        currentInput,
        currentOperationLabel
    );

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_backspace_button_when_there_is_only_zero_in_the_input_field_does_not_change_the_input_field()
    {
        _testBuilder
            .Arrange(state => state.SetToStart)
            .Act(CreateEvent)
            .AssertInputFieldTextDoesNotChange();
    }
    
    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_backspace_button_when_there_is_only_zero_in_the_input_field_does_not_change_the_operation_label()
    {
        _testBuilder
            .Arrange(state => state.SetToStart)
            .Act(CreateEvent)
            .AssertOperationLabelTextDoesNotChange();
    }
    

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_backspace_button_when_there_is_only_one_digit_left_in_the_input_field_replaces_the_input_with_zero()
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumber)
            .Act(CreateEvent)
            .AssertInputFieldTextReset();
    }
    
    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_backspace_button_when_there_is_only_one_digit_left_in_the_input_field_does_not_change_the_operation_label()
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumber)
            .Act(CreateEvent)
            .AssertOperationLabelTextDoesNotChange();
    }

    [Ignore("not able to test right now")]
    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_backspace_button_when_there_is_more_then_one_digit_in_the_input_field_removes_the_last_digit_in_the_input_field()
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumber)
            .Act(CreateEvent)
            .AssertInputFieldText(start => start.InputFieldText[..^1]);
    }
    [Ignore("not able to test right now")]
    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_backspace_button_when_there_is_more_then_one_digit_in_the_input_field_does_not_change_the_operation_label()
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumber)
            .Act(CreateEvent)
            .AssertOperationLabelTextDoesNotChange();
    }
    

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_backspace_button_when_the_last_digit_in_the_input_field_is_the_decimal_point_removes_the_decimal_point()
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumberDecimal)
            .Act(CreateEvent)
            .AssertInputFieldText(start => start.InputFieldText[..^1]);
    }
    
    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_backspace_button_when_the_last_digit_in_the_input_field_is_the_decimal_point_does_not_change_the_operation_label()
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumberDecimal)
            .Act(CreateEvent)
            .AssertOperationLabelTextDoesNotChange();
    }
    
    [Ignore("not able to test right now")]
    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_backspace_button_when_there_is_a_digit_after_a_decimal_point_in_the_input_field_removes_the_last_digit_in_the_input_field()
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumberDecimal)
            .Act(CreateEvent)
            .AssertInputFieldText(start => start.InputFieldText[..^1]);
    }
    
    [Ignore("not able to test right now")]
    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_backspace_button_when_there_is_a_digit_after_a_decimal_point_in_the_input_field_does_not_change_the_operation_label()
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumberDecimal)
            .Act(CreateEvent)
            .AssertOperationLabelTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void Pressing_the_operator_button_directly_after_an_operator_is_set_does_not_change_the_input_field()
    {
        _testBuilder
            .Arrange(state => state.SetToOperator)
            .Act(CreateEvent)
            .AssertInputFieldTextDoesNotChange();
    }
    
    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void Pressing_the_operator_button_directly_after_an_operator_is_set_does_not_change_the_operation_label()
    {
        _testBuilder
            .Arrange(state => state.SetToOperator)
            .Act(CreateEvent)
            .AssertOperationLabelTextDoesNotChange();
    }
}