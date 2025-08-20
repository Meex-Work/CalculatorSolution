namespace DependencyInjection.Strategies.Interfaces;

public interface IStrategyListBuilderEntry<TContext, TTarget>
    where TContext : notnull
{
    public IStrategyListBuilderEntryContext<TContext, TTarget> Strategy(TTarget target);
}