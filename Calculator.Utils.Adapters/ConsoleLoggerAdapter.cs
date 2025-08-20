using Calculator.Utils.Interfaces.Logging;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Calculator.Utils.Adapters;

public sealed class ConsoleLoggerAdapter(
    ILogger adaptee
) : IDebugLogger
{
    public void Debug(string message) => adaptee.LogDebug("{Message}", message);
}