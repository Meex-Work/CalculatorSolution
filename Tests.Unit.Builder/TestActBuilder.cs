using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Interfaces;
using Tests.Unit.Interfaces;

namespace Tests.Unit.Builder;

internal sealed class TestActBuilder<TEvent>(
    IEventHandler<TEvent> sut,
    TEvent startEvent
) :
    ITestActBuilder<TEvent>
    where TEvent : CalculatorEvent
{
    public ITestAssertBuilder<TEvent> Act(Func<string, string, TEvent> eventFunc)
    {
        var assertEvent = sut.Handle(
            eventFunc(
                startEvent.InputFieldText,
                startEvent.OperationLabelText
            )
        );
        return new TestAssertBuilder<TEvent>(
            startEvent,
            assertEvent
        );
    }
}