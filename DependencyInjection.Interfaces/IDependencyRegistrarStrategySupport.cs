using DependencyInjection.Strategies.Interfaces;

namespace DependencyInjection.Interfaces;

public interface IDependencyRegistrarStrategySupport
{
    public IDependencyRegistrarOrBuild RegisterStrategy<TStrategy, TContext, TTarget>(
        Func<IDependencyProvider, TStrategy> factory
    ) where TStrategy : IStrategy<TContext, TTarget>;

    public IDependencyRegistrarOrBuild RegisterStrategy<TStrategy, TContext, TTarget>(
        Func<IStrategyListBuilderEntry<TContext, TTarget>, IStrategyListBuilderBuild<TContext, TTarget>> strategyBuilder
    ) where TStrategy : IStrategy<TContext, TTarget>
        where TContext : notnull;

    public IDependencyRegistrarOrBuild RegisterStrategy<TStrategy, TContext, TTarget>(
        Func<
            IDependencyProvider,
            IStrategyListBuilderEntry<TContext, TTarget>,
            IStrategyListBuilderBuild<TContext, TTarget>
        > strategyBuilder
    ) where TStrategy : IStrategy<TContext, TTarget>
        where TContext : notnull;
}