using Calculator.Events;
using Tests.Unit.Builder;
using Tests.Unit.Interfaces;

namespace Tests.Unit;

[TestFixture]
[Parallelizable(ParallelScope.Fixtures)]
public sealed class CalculatorFormClickedDecimalButtonEventTests
{
    private readonly ITestBuilder<ClickedDecimalButtonEvent> _testBuilder =
        CalculatorFormEventTestBuilder.Create(
            new ClickedDecimalButtonEvent("0", string.Empty)
        );

    private static ClickedDecimalButtonEvent CreateEvent(
        string inputField,
        string operationLabel
    ) => new(
        inputField,
        operationLabel
    );

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_decimal_button_when_there_is_only_zero_in_the_input_field_appends_the_decimal_point_to_the_input_field()
    {
        _testBuilder
            .Arrange(state => state.SetToStart)
            .Act(CreateEvent)
            .AssertInputFieldText(start => start.InputFieldText + ".");
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_decimal_button_when_there_is_only_zero_in_the_input_field_does_not_change_the_operation_label()
    {
        _testBuilder
            .Arrange(state => state.SetToStart)
            .Act(CreateEvent)
            .AssertOperationLabelTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_decimal_button_when_there_is_a_number_in_the_input_appends_the_decimal_point_to_the_input_field()
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumber)
            .Act(CreateEvent)
            .AssertInputFieldText(start => start.InputFieldText + ".");
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void Pressing_the_decimal_button_when_there_is_a_number_in_the_input_does_not_change_the_operation_label()
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumber)
            .Act(CreateEvent)
            .AssertOperationLabelTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void Pressing_the_decimal_button_when_there_is_a_decimal_point_in_the_input_does_not_change_the_input_field()
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumberDecimal)
            .Act(CreateEvent)
            .AssertInputFieldTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_decimal_button_when_there_is_a_decimal_point_in_the_input_does_not_change_the_operation_label()
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumberDecimal)
            .Act(CreateEvent)
            .AssertOperationLabelTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void Pressing_the_decimal_button_after_an_operator_appends_the_decimal_point_to_the_input_field()
    {
        _testBuilder
            .Arrange(state => state.SetToOperator)
            .Act(CreateEvent)
            .AssertInputFieldText(start => start.InputFieldText + ".");
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void Pressing_the_decimal_button_after_an_operator_is_set_does_not_change_the_operation_label()
    {
        _testBuilder
            .Arrange(state => state.SetToOperator)
            .Act(CreateEvent)
            .AssertOperationLabelTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_decimal_button_after_an_operator_is_set_when_a_number_is_in_the_input_field_appends_the_decimal_point_to_the_input_field()
    {
        _testBuilder
            .Arrange(state => state.SetToSecondNumber)
            .Act(CreateEvent)
            .AssertInputFieldText(start => start.InputFieldText + ".");
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_decimal_button_after_an_operator_is_set_when_a_number_is_in_the_input_field_does_not_change_the_operation_label()
    {
        _testBuilder
            .Arrange(state => state.SetToSecondNumber)
            .Act(CreateEvent)
            .AssertOperationLabelTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_decimal_button_after_an_operator_when_there_is_a_decimal_point_in_the_input_field_does_not_change_the_input_field()
    {
        _testBuilder
            .Arrange(state => state.SetToSecondNumberDecimal)
            .Act(CreateEvent)
            .AssertInputFieldTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_decimal_button_after_an_operator_when_there_is_a_decimal_point_in_the_input_field_does_not_change_the_operation_label()
    {
        _testBuilder
            .Arrange(state => state.SetToSecondNumberDecimal)
            .Act(CreateEvent)
            .AssertOperationLabelTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_decimal_button_after_calculation_replaces_the_input_field_with_zero_and_appends_a_decimal_point()
    {
        _testBuilder
            .Arrange(state => state.SetToResult)
            .Act(CreateEvent)
            .AssertInputFieldText(_ => "0.");
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void
        Pressing_the_decimal_button_after_calculation_resets_the_operation_display()
    {
        _testBuilder
            .Arrange(state => state.SetToResult)
            .Act(CreateEvent)
            .AssertOperationLabelTextReset();
    }
}