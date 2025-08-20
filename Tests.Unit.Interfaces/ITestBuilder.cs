using Calculator.Events.Abstracts;

namespace Tests.Unit.Interfaces;

public interface ITestBuilder<TEvent> where TEvent : CalculatorEvent
{
    public ITestActBuilder<TEvent> Arrange(Func<ITestArrangeBuilder<TEvent>, Func<TEvent>> configuration);
}