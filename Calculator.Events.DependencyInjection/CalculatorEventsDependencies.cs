using Calculator.Events.Handlers.Facades;
using Calculator.Events.Handlers.Interfaces;
using DependencyInjection.Interfaces;

namespace Calculator.Events.DependencyInjection;

public static class CalculatorEventsDependencies
{
    public static IDependencyRegistrarOrBuild RegisterEvents(this IDependencyRegistrar registrar) => registrar
        .RegisterClickedNumberButtonEvent()
        .RegisterClickedDecimalButtonEvent()
        .RegisterClickedOperatorButtonEvent()
        .RegisterClickedEqualButtonEvent()
        .RegisterClickedClearButtonEvent()
        .RegisterClickedBackspaceButtonEvent()
        .Register<ICalculatorEventHandlerFacade>(provider =>
            new CalculatorEventHandlerFacade(
                provider.Resolve<IEventHandler<ClickedNumberButtonEvent>>(),
                provider.Resolve<IEventHandler<ClickedDecimalButtonEvent>>(),
                provider.Resolve<IEventHandler<ClickedOperatorButtonEvent>>(),
                provider.Resolve<IEventHandler<ClickedEqualButtonEvent>>(),
                provider.Resolve<IEventHandler<ClickedClearButtonEvent>>(),
                provider.Resolve<IEventHandler<ClickedBackspaceButtonEvent>>()
            )
        );
}