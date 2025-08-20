using Calculator.Utils;
using DependencyInjection.Strategies.Interfaces;

namespace DependencyInjection.Strategies;

public static class StrategyList
{
    public static IStrategyListBuilderEntry<TContext, TTarget> Create<TContext, TTarget>()
        where TContext : notnull
        => new StrategyList<TContext, TTarget>.StrategyListBuilder();
}

internal sealed class StrategyList<TContext, TTarget> :
    IStrategyList<TContext, TTarget>
    where TContext : notnull
{
    private readonly Dictionary<TContext, TTarget> _strategies;

    private StrategyList(Dictionary<TContext, TTarget> strategies) => _strategies = strategies;
    
    public TTarget Is(TContext context)
        => Maybe<TTarget>
            .Some(_strategies.GetValueOrDefault(context))
            .OrThrow();
    
    internal sealed class StrategyListBuilder : IStrategyListBuilderDsl<TContext, TTarget>
    {
        private readonly Dictionary<TContext, TTarget> _strategies = new();
        private Maybe<TTarget> _strategy = Maybe<TTarget>.None;

        public IStrategyListBuilderEntryContext<TContext, TTarget> Strategy(TTarget target)
        {
            _strategy = Maybe<TTarget>.Some(target);
            return this;
        }

        public IStrategyListBuilderEntryOrBuild<TContext, TTarget> For(TContext context)
        {
            _strategies.Add(context, _strategy.OrThrow());
            return this;
        }

        public IStrategyList<TContext, TTarget> Build()
        {
            return new StrategyList<TContext, TTarget>(_strategies);
        }
    }
}