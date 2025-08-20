using Calculator.Events;
using Tests.Unit.Builder;
using Tests.Unit.Interfaces;

namespace Tests.Unit;

[TestFixture]
[Parallelizable(ParallelScope.Fixtures)]
public sealed class CalculatorFormClickedClearButtonEventTests
{
    private readonly ITestBuilder<ClickedClearButtonEvent> _testBuilder =
        CalculatorFormEventTestBuilder.Create(
            new ClickedClearButtonEvent("0", string.Empty)
        );

    private static ClickedClearButtonEvent CreateEvent(
        string inputField,
        string operationLabel
    ) => new(
        inputField,
        operationLabel
    );

    private static readonly IEnumerable<
        Func<ITestArrangeBuilder<ClickedClearButtonEvent>, Func<ClickedClearButtonEvent>>
    > StateFunc = ITestArrangeBuilder<ClickedClearButtonEvent>.List;

    [Test, TestCaseSource(nameof(StateFunc))]
    [Parallelizable(ParallelScope.Self)]
    public void Pressing_the_clear_button_in_any_state_will_reset_the_input_field_text(
        Func<ITestArrangeBuilder<ClickedClearButtonEvent>, Func<ClickedClearButtonEvent>> stateFunc
    )
    {
        _testBuilder
            .Arrange(stateFunc)
            .Act(CreateEvent)
            .AssertInputFieldTextReset();
    }

    [Test, TestCaseSource(nameof(StateFunc))]
    [Parallelizable(ParallelScope.Self)]
    public void Pressing_the_clear_button_in_any_state_will_reset_the_operation_label_text(
        Func<ITestArrangeBuilder<ClickedClearButtonEvent>, Func<ClickedClearButtonEvent>> stateFunc
    )
    {
        _testBuilder
            .Arrange(stateFunc)
            .Act(CreateEvent)
            .AssertOperationLabelTextReset();
    }
}