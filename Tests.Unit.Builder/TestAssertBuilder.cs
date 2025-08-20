using Calculator.Events.Abstracts;
using FluentAssertions;
using Tests.Unit.Interfaces;

namespace Tests.Unit.Builder;

internal sealed class TestAssertBuilder<TEvent>(
    TEvent startEvent,
    TEvent assertEvent
) :
    ITestAssertBuilder<TEvent>
    where TEvent : CalculatorEvent
{
    public void AssertInputFieldText(Func<TEvent, string> func)
    {
        assertEvent.InputFieldText.Should().Be(func(startEvent));
    }

    public void AssertInputFieldTextDoesNotChange()
    {
        assertEvent.InputFieldText.Should().Be(startEvent.InputFieldText);
    }

    public void AssertInputFieldTextReset()
    {
        assertEvent.InputFieldText.Should().Be("0");
    }

    public void AssertOperationLabelText(Func<TEvent, string> func)
    {
        assertEvent.OperationLabelText.Should().Be(func(startEvent));
    }

    public void AssertOperationLabelTextDoesNotChange()
    {
        assertEvent.OperationLabelText.Should().Be(startEvent.OperationLabelText);
    }

    public void AssertOperationLabelTextReset()
    {
        assertEvent.OperationLabelText.Should().Be(string.Empty);
    }
}