using Autofac;
using DependencyInjection.Interfaces;
using DependencyInjection.Strategies.Interfaces;

namespace DependencyInjection.Adapters;

public sealed class AutofacContainerAdapter : IDependencyContainer
{
    private readonly IComponentContext _adaptee;
    private AutofacContainerAdapter(IComponentContext adaptee) => _adaptee = adaptee;
    private static AutofacContainerAdapter Create(IComponentContext adaptee) => new(adaptee);
    public static IDependencyContainerBuilder Builder() => AutofacContainerAdapterBuilder.Create();

    public TService Resolve<TService>() where TService : notnull => _adaptee.Resolve<TService>();

    private sealed class AutofacContainerAdapterBuilder : IDependencyContainerBuilder
    {
        private readonly ContainerBuilder _adaptee;
        private readonly IDependencyRegistrarDecoratorSupport _decoratorSupport;
        private readonly IDependencyRegistrarCompositeSupport _compositeSupport;
        private readonly IDependencyRegistrarStrategySupport _strategySupport;
        private readonly IDependencyRegistrarSingletonSupport _singletonSupport;
        private readonly IDependencyRegistrarAdapterSupport _adapterSupport;

        private AutofacContainerAdapterBuilder(ContainerBuilder adaptee)
        {
            _adaptee = adaptee;

            var builderSupportData = new BuilderSupportData(_adaptee);

            _decoratorSupport = AutofacContainerAdapterBuilderDecoratorSupport.Create(builderSupportData);
            _compositeSupport = AutofacContainerAdapterBuilderCompositeSupport.Create(builderSupportData);
            _strategySupport = AutofacContainerAdapterBuilderStrategySupport.Create(builderSupportData);
            _singletonSupport = AutofacContainerAdapterBuilderSingletonSupport.Create(builderSupportData);
            _adapterSupport = AutofacContainerAdapterBuilderAdapterSupport.Create(builderSupportData);
        }

        internal static IDependencyContainerBuilder Create() => Create(new ContainerBuilder());

        internal static IDependencyContainerBuilder Create(ContainerBuilder adaptee) =>
            new AutofacContainerAdapterBuilder(adaptee);

        public IDependencyRegistrarOrBuild Register<TService>(
            Func<IDependencyProvider, TService> factory
        ) where TService : notnull
        {
            _adaptee.Register(context => factory(AutofacContainerAdapter.Create(context)));
            return this;
        }

        public IDependencyRegistrarOrBuild RegisterDecorator<TService>(
            Func<IDependencyProvider, TService, TService> factory
        ) where TService : class
            => _decoratorSupport.RegisterDecorator(factory);

        public IDependencyRegistrarOrBuild RegisterComposite<TService>(
            Func<IDependencyProvider, IEnumerable<TService>, TService> factory
        ) where TService : class
            => _compositeSupport.RegisterComposite(factory);

        public IDependencyRegistrarOrBuild RegisterStrategy<TStrategy, TContext, TTarget>(
            Func<IDependencyProvider, TStrategy> factory
        ) where TStrategy : IStrategy<TContext, TTarget>
            => _strategySupport.RegisterStrategy<TStrategy, TContext, TTarget>(factory);

        public IDependencyRegistrarOrBuild RegisterStrategy<TStrategy, TContext, TTarget>(
            Func<
                IStrategyListBuilderEntry<TContext, TTarget>,
                IStrategyListBuilderBuild<TContext, TTarget>
            > strategyBuilder
        ) where TStrategy : IStrategy<TContext, TTarget>
            where TContext : notnull
            => _strategySupport.RegisterStrategy<TStrategy, TContext, TTarget>(strategyBuilder);

        public IDependencyRegistrarOrBuild RegisterStrategy<TStrategy, TContext, TTarget>(
            Func<
                IDependencyProvider,
                IStrategyListBuilderEntry<TContext, TTarget>,
                IStrategyListBuilderBuild<TContext, TTarget>
            > strategyBuilder
        ) where TStrategy : IStrategy<TContext, TTarget>
            where TContext : notnull
            => _strategySupport.RegisterStrategy<TStrategy, TContext, TTarget>(strategyBuilder);

        public IDependencyRegistrarOrBuild RegisterSingleton<TService>(
            Func<IDependencyProvider, TService> factory
        ) where TService : class
            => _singletonSupport.RegisterSingleton(factory);

        public IDependencyRegistrarOrBuild RegisterAdapter<TService, TAdapter>(
            Func<IDependencyProvider, TService, TAdapter> factory
        ) where TAdapter : notnull
            where TService : notnull
            => _adapterSupport.RegisterAdapter(factory);

        public IDependencyContainer Build() => new AutofacContainerAdapter(_adaptee.Build());
    }

    public sealed record BuilderSupportData(ContainerBuilder Adaptee)
    {
        public Func<IComponentContext, IDependencyProvider> UpdateProvider { get; } = Create;

        public Func<ContainerBuilder, IDependencyRegistrarOrBuild> UpdateRegistrar { get; } =
            AutofacContainerAdapterBuilder.Create;
    }
}