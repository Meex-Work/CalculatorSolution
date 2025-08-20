using Calculator.Events.Abstracts;

namespace Tests.Unit.Interfaces;

public interface ITestAssertBuilder<out TEvent>
    where TEvent : CalculatorEvent
{
    public void AssertInputFieldText(Func<TEvent, string> func);
    public void AssertInputFieldTextDoesNotChange();
    public void AssertInputFieldTextReset();
    public void AssertOperationLabelText(Func<TEvent, string> func);
    public void AssertOperationLabelTextDoesNotChange();
    public void AssertOperationLabelTextReset();
}