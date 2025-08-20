using Calculator.Events.Handlers.Interfaces;
using DependencyInjection;

namespace Calculator;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        var provider = Factory.Build();
        Application.Run(
            CalculatorForm.Create(provider.Resolve<ICalculatorEventHandlerFacade>())
        );
    }
}