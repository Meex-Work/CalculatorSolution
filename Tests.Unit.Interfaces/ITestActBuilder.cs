using Calculator.Events.Abstracts;

namespace Tests.Unit.Interfaces;

public interface ITestActBuilder<TEvent>
    where TEvent : CalculatorEvent
{
    public ITestAssertBuilder<TEvent> Act(Func<string, string, TEvent> @event);
}