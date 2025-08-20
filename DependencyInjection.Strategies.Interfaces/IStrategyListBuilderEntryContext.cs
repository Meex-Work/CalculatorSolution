namespace DependencyInjection.Strategies.Interfaces;

public interface IStrategyListBuilderEntryContext<TContext, TTarget>
    where TContext : notnull
{
    public IStrategyListBuilderEntryOrBuild<TContext, TTarget> For(TContext context);
}