using Calculator.Utils.Adapters;
using Calculator.Utils.Interfaces.Logging;
using DependencyInjection.Interfaces;
using Microsoft.Extensions.Logging;

namespace Calculator.Utils.Dependencies;

public static class CalculatorUtilsDependencies
{
    public static IDependencyRegistrarOrBuild RegisterUtils(this IDependencyRegistrar registrar) => registrar
        .Register<IDebugLogger>(_ => new ConsoleLoggerAdapter(
                LoggerFactory.Create(builder => builder
                        .AddConsole(configure => configure
                                .LogToStandardErrorThreshold = LogLevel.Debug
                        )
                    )
                    .CreateLogger<ConsoleLoggerAdapter>()
            )
        );
}