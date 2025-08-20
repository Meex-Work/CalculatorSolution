using Autofac;
using DependencyInjection.Interfaces;
using DependencyInjection.Strategies;
using DependencyInjection.Strategies.Interfaces;

namespace DependencyInjection.Adapters;

public sealed class AutofacContainerAdapterBuilderStrategySupport : IDependencyRegistrarStrategySupport
{
    private readonly AutofacContainerAdapter.BuilderSupportData _data;

    private AutofacContainerAdapterBuilderStrategySupport(AutofacContainerAdapter.BuilderSupportData data) =>
        _data = data;

    public static IDependencyRegistrarStrategySupport Create(AutofacContainerAdapter.BuilderSupportData data) =>
        new AutofacContainerAdapterBuilderStrategySupport(data);

    public IDependencyRegistrarOrBuild RegisterStrategy<TStrategy, TContext, TTarget>(
        Func<
            IDependencyProvider,
            TStrategy
        > factory
    ) where TStrategy : IStrategy<TContext, TTarget>
    {
        var adaptee = _data.Adaptee;

        adaptee.Register(context => factory(_data.UpdateProvider(context)));

        return _data.UpdateRegistrar(adaptee);
    }

    public IDependencyRegistrarOrBuild RegisterStrategy<TStrategy, TContext, TTarget>(
        Func<
            IStrategyListBuilderEntry<TContext, TTarget>,
            IStrategyListBuilderBuild<TContext, TTarget>
        > strategyBuilder
    ) where TStrategy : IStrategy<TContext, TTarget>
        where TContext : notnull
        => RegisterStrategy<TStrategy, TContext, TTarget>(_ => (TStrategy)Strategy.Create(strategyBuilder));

    public IDependencyRegistrarOrBuild RegisterStrategy<TStrategy, TContext, TTarget>(
        Func<
            IDependencyProvider,
            IStrategyListBuilderEntry<TContext, TTarget>,
            IStrategyListBuilderBuild<TContext, TTarget>
        > strategyBuilder
    ) where TStrategy : IStrategy<TContext, TTarget>
        where TContext : notnull
        => RegisterStrategy<TStrategy, TContext, TTarget>(provider =>
            (TStrategy)Strategy.Create(provider, strategyBuilder)
        );
}