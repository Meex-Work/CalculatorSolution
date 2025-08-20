using Calculator.Events;
using Tests.Unit.Builder;
using Tests.Unit.Interfaces;

namespace Tests.Unit;

[TestFixture]
[Parallelizable(ParallelScope.Fixtures)]
public sealed class CalculatorFormClickedNumberButtonEventTests
{
    private readonly ITestBuilder<ClickedNumberButtonEvent> _testBuilder =
        CalculatorFormEventTestBuilder.Create(
            new ClickedNumberButtonEvent("0", "0", string.Empty)
        );

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void Pressing_zero_when_there_is_only_zero_in_the_input_field_does_not_change_the_input_field()
    {
        _testBuilder
            .Arrange(state => state.SetToStart)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedNumberButtonEvent(
                    "0",
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertInputFieldTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void Pressing_zero_when_there_is_only_zero_in_the_input_field_does_not_change_the_operation_label()
    {
        _testBuilder
            .Arrange(state => state.SetToStart)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedNumberButtonEvent(
                    "0",
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertOperationLabelTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    [TestCase("1")]
    [TestCase("2")]
    [TestCase("3")]
    [TestCase("4")]
    [TestCase("5")]
    [TestCase("6")]
    [TestCase("7")]
    [TestCase("8")]
    [TestCase("9")]
    public void
        Pressing_a_non_zero_number_when_there_is_only_zero_in_the_input_field_replaces_the_zero_in_the_input_field(
            string number
        )
    {
        _testBuilder
            .Arrange(state => state.SetToStart)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedNumberButtonEvent(
                    number,
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertInputFieldText(_ => number);
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    [TestCase("1")]
    [TestCase("2")]
    [TestCase("3")]
    [TestCase("4")]
    [TestCase("5")]
    [TestCase("6")]
    [TestCase("7")]
    [TestCase("8")]
    [TestCase("9")]
    public void
        Pressing_a_non_zero_number_when_there_is_only_zero_in_the_input_field_does_not_change_the_operation_label(
            string number
        )
    {
        _testBuilder
            .Arrange(state => state.SetToStart)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedNumberButtonEvent(
                    number,
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertOperationLabelTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    [TestCase("0")]
    [TestCase("1")]
    [TestCase("2")]
    [TestCase("3")]
    [TestCase("4")]
    [TestCase("5")]
    [TestCase("6")]
    [TestCase("7")]
    [TestCase("8")]
    [TestCase("9")]
    public void
        Pressing_a_number_when_there_is_at_least_one_non_zero_number_in_the_input_field_appends_the_number_in_the_input_field(
            string number
        )
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumber)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedNumberButtonEvent(
                    number,
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertInputFieldText(start => start.InputFieldText + number);
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    [TestCase("0")]
    [TestCase("1")]
    [TestCase("2")]
    [TestCase("3")]
    [TestCase("4")]
    [TestCase("5")]
    [TestCase("6")]
    [TestCase("7")]
    [TestCase("8")]
    [TestCase("9")]
    public void
        Pressing_a_number_when_there_is_at_least_one_non_zero_number_in_the_input_field_does_not_change_the_operation_label(
            string number
        )
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumber)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedNumberButtonEvent(
                    number,
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertOperationLabelTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    [TestCase("0")]
    [TestCase("1")]
    [TestCase("2")]
    [TestCase("3")]
    [TestCase("4")]
    [TestCase("5")]
    [TestCase("6")]
    [TestCase("7")]
    [TestCase("8")]
    [TestCase("9")]
    public void
        Pressing_a_number_after_there_is_a_decimal_point_in_the_input_field_appends_the_number_in_the_input_field(
            string number
        )
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumberDecimal)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedNumberButtonEvent(
                    number,
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertInputFieldText(start => start.InputFieldText + number);
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    [TestCase("0")]
    [TestCase("1")]
    [TestCase("2")]
    [TestCase("3")]
    [TestCase("4")]
    [TestCase("5")]
    [TestCase("6")]
    [TestCase("7")]
    [TestCase("8")]
    [TestCase("9")]
    public void
        Pressing_a_number_after_there_is_a_decimal_point_in_the_input_field_does_not_change_the_operation_label(
            string number
        )
    {
        _testBuilder
            .Arrange(state => state.SetToFirstNumberDecimal)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedNumberButtonEvent(
                    number,
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertOperationLabelTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void Pressing_zero_directly_after_an_operator_is_set_does_not_change_the_input_field()
    {
        _testBuilder
            .Arrange(state => state.SetToOperator)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedNumberButtonEvent(
                    "0",
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertInputFieldTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    public void Pressing_zero_directly_after_an_operator_is_set_does_not_change_the_operation_label()
    {
        _testBuilder
            .Arrange(state => state.SetToOperator)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedNumberButtonEvent(
                    "0",
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertOperationLabelTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    [TestCase("1")]
    [TestCase("2")]
    [TestCase("3")]
    [TestCase("4")]
    [TestCase("5")]
    [TestCase("6")]
    [TestCase("7")]
    [TestCase("8")]
    [TestCase("9")]
    public void
        Pressing_a_non_zero_number_directly_after_an_operator_is_set_replaces_the_zero_in_the_input_field(
            string number
        )
    {
        _testBuilder
            .Arrange(state => state.SetToOperator)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedNumberButtonEvent(
                    number,
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertInputFieldText(_ => number);
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    [TestCase("1")]
    [TestCase("2")]
    [TestCase("3")]
    [TestCase("4")]
    [TestCase("5")]
    [TestCase("6")]
    [TestCase("7")]
    [TestCase("8")]
    [TestCase("9")]
    public void
        Pressing_a_non_zero_number_directly_after_an_operator_is_set_does_not_change_the_operation_label(
            string number
        )
    {
        _testBuilder
            .Arrange(state => state.SetToOperator)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedNumberButtonEvent(
                    number,
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertOperationLabelTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    [TestCase("0")]
    [TestCase("1")]
    [TestCase("2")]
    [TestCase("3")]
    [TestCase("4")]
    [TestCase("5")]
    [TestCase("6")]
    [TestCase("7")]
    [TestCase("8")]
    [TestCase("9")]
    public void
        Pressing_a_number_after_an_operator_when_there_is_at_least_one_non_zero_number_in_the_input_field_appends_the_number_in_the_input_field(
            string number
        )
    {
        _testBuilder
            .Arrange(state => state.SetToSecondNumber)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedNumberButtonEvent(
                    number,
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertInputFieldText(start => start.InputFieldText + number);
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    [TestCase("0")]
    [TestCase("1")]
    [TestCase("2")]
    [TestCase("3")]
    [TestCase("4")]
    [TestCase("5")]
    [TestCase("6")]
    [TestCase("7")]
    [TestCase("8")]
    [TestCase("9")]
    public void
        Pressing_a_number_after_an_operator_when_there_is_at_least_one_non_zero_number_in_the_input_field_does_not_change_the_operation_label(
            string number
        )
    {
        _testBuilder
            .Arrange(state => state.SetToSecondNumber)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedNumberButtonEvent(
                    number,
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertOperationLabelTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    [TestCase("0")]
    [TestCase("1")]
    [TestCase("2")]
    [TestCase("3")]
    [TestCase("4")]
    [TestCase("5")]
    [TestCase("6")]
    [TestCase("7")]
    [TestCase("8")]
    [TestCase("9")]
    public void
        Pressing_a_number_after_an_operator_after_there_is_a_decimal_point_in_the_input_field_appends_the_number_in_the_input_field(
            string number
        )
    {
        _testBuilder
            .Arrange(state => state.SetToSecondNumberDecimal)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedNumberButtonEvent(
                    number,
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertInputFieldText(start => start.InputFieldText + number);
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    [TestCase("0")]
    [TestCase("1")]
    [TestCase("2")]
    [TestCase("3")]
    [TestCase("4")]
    [TestCase("5")]
    [TestCase("6")]
    [TestCase("7")]
    [TestCase("8")]
    [TestCase("9")]
    public void
        Pressing_a_number_after_an_operator_after_there_is_a_decimal_point_in_the_input_field_does_not_change_the_operation_label(
            string number
        )
    {
        _testBuilder
            .Arrange(state => state.SetToSecondNumberDecimal)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedNumberButtonEvent(
                    number,
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertOperationLabelTextDoesNotChange();
    }

    [Test]
    [Parallelizable(ParallelScope.Self)]
    [TestCase("0")]
    [TestCase("1")]
    [TestCase("2")]
    [TestCase("3")]
    [TestCase("4")]
    [TestCase("5")]
    [TestCase("6")]
    [TestCase("7")]
    [TestCase("8")]
    [TestCase("9")]
    public void Pressing_a_number_after_calculation_replaces_the_result_in_the_input_field_with_zero(
        string number
    )
    {
        _testBuilder
            .Arrange(state => state.SetToResult)
            .Act((currentInputField, currentOperationLabel) =>
                new ClickedNumberButtonEvent(
                    number,
                    currentInputField,
                    currentOperationLabel
                )
            )
            .AssertInputFieldText(_ => number);
    }
}