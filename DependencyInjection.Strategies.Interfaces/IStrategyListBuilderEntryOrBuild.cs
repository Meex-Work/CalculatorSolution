namespace DependencyInjection.Strategies.Interfaces;

public interface IStrategyListBuilderEntryOrBuild<TContext, TTarget> :
    IStrategyListBuilderEntry<TContext, TTarget>,
    IStrategyListBuilderBuild<TContext, TTarget>
    where TContext : notnull;