using Calculator.Utils;

namespace Calculator.Services.Interfaces;

/// <summary>
/// Defines a generic service interface for processing input and returning results.
/// </summary>
/// <typeparam name="TInput">The contravariant input type (accepts more derived types)</typeparam>
/// <typeparam name="TResult">The covariant result type (returns more specific types)</typeparam>
/// <remarks>
/// This interface combines both input (consumer) and output (producer) variance,
/// making it suitable for service patterns where input is processed to produce results.
/// </remarks>
public interface IService<in TInput, out TResult>
{
    /// <summary>
    /// Executes the service operation with the given input.
    /// </summary>
    /// <param name="input">The input data for processing</param>
    /// <returns>The result of the service operation</returns>
    /// <exception cref="ArgumentNullException">Thrown when input is null</exception>
    /// <exception cref="InvalidOperationException">Thrown when service cannot process the input</exception>
    /// <remarks>
    /// Implementations should:
    /// <list type="bullet">
    /// <item><description>Validate input parameters</description></item>
    /// <item><description>Handle all business logic processing</description></item>
    /// <item><description>Return appropriate results or throw meaningful exceptions</description></item>
    /// </list>
    /// The variance annotations (<c>in</c>/<c>out</c>) enable more flexible usage in inheritance scenarios.
    /// </remarks>
    public TResult Execute(TInput input);
}