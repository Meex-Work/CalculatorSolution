namespace Calculator.Queries.Handlers.Interfaces;

/// <summary>
/// Defines a handler for retrieving data (query) in a CQRS pattern.
/// </summary>
/// <typeparam name="TResult">The covariant type of result returned by the query</typeparam>
/// <remarks>
/// This interface follows the Command Query Responsibility Segregation (CQRS) principle
/// by separating read operations (queries) from write operations (commands).
/// </remarks>
public interface IQueryHandler<out TResult>
{
    /// <summary>
    /// Executes the query and returns the result.
    /// </summary>
    /// <returns>The query result</returns>
    /// <exception cref="System.Exception">May throw exceptions for query failures</exception>
    /// <remarks>
    /// Implementations should:
    /// <list type="bullet">
    /// <item><description>Contain all logic needed to retrieve the requested data</description></item>
    /// <item><description>Handle any data access or business logic required</description></item>
    /// <item><description>Return a fully populated result object</description></item>
    /// </list>
    /// The <see cref="out"/> modifier on TResult allows for more flexible return types.
    /// </remarks>
    public TResult Query();
}