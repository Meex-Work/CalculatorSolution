using DependencyInjection.Interfaces;
using DependencyInjection.Strategies.Interfaces;

namespace DependencyInjection.Strategies;

public static class Strategy
{
    public static IStrategy<TContext, TTarget> Create<TContext, TTarget>(
        IStrategyList<TContext, TTarget> strategyList
    ) where TContext : notnull
        => new Strategy<TContext, TTarget>(strategyList);

    public static IStrategy<TContext, TTarget> Create<TContext, TTarget>(
        Func<
            IStrategyListBuilderEntry<TContext, TTarget>,
            IStrategyListBuilderBuild<TContext, TTarget>
        > builder
    ) where TContext : notnull
        => Create(builder(StrategyList.Create<TContext, TTarget>()).Build());

    public static IStrategy<TContext, TTarget> Create<TContext, TTarget>(
        IDependencyProvider provider,
        Func<
            IDependencyProvider,
            IStrategyListBuilderEntry<TContext, TTarget>,
            IStrategyListBuilderBuild<TContext, TTarget>
        > builder
    ) where TContext : notnull
        => Create(builder(provider, StrategyList.Create<TContext, TTarget>()).Build());
}

internal sealed class Strategy<TContext, TTarget> :
    IStrategy<TContext, TTarget>
    where TContext : notnull
{
    private readonly IStrategyList<TContext, TTarget> _strategyList;

    internal Strategy(IStrategyList<TContext, TTarget> strategyList) => _strategyList = strategyList;

    public TTarget Get(TContext context) => _strategyList.Is(context);
}