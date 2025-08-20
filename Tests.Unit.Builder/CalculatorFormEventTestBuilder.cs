using Calculator.Events.Abstracts;
using Calculator.Events.Handlers.Interfaces;
using DependencyInjection;
using Tests.Unit.Interfaces;

namespace Tests.Unit.Builder;

public static class CalculatorFormEventTestBuilder
{
    public static ITestBuilder<TEvent> Create<TEvent>(TEvent startEvent)
        where TEvent : CalculatorEvent
        => new CalculatorFormEventTestBuilder<TEvent>(startEvent);
}

internal sealed class CalculatorFormEventTestBuilder<TEvent>(
    TEvent startEvent
) : ITestBuilder<TEvent>
    where TEvent : CalculatorEvent
{
    public ITestActBuilder<TEvent> Arrange(
        Func<ITestArrangeBuilder<TEvent>, Func<TEvent>> configuration
    )
    {
        var provider = Factory.Build();

        var testEvent = configuration(
                new TestArrangeBuilder<TEvent>(
                    provider.Resolve<ICalculatorEventHandlerFacade>(),
                    startEvent
                )
            )
            .Invoke();

        return new TestActBuilder<TEvent>(
            provider.Resolve<IEventHandler<TEvent>>(),
            testEvent
        );
    }
}