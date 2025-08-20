namespace DependencyInjection.Strategies.Interfaces;

public interface IStrategyList<in TContext, out TTarget>
    where TContext : notnull
{
    public TTarget Is(TContext context);
}