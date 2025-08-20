namespace DependencyInjection.Strategies.Interfaces;

public interface IStrategyListBuilderDsl<TContext, TTarget> :
    IStrategyListBuilderEntryContext<TContext, TTarget>,
    IStrategyListBuilderEntryOrBuild<TContext, TTarget>
    where TContext : notnull;