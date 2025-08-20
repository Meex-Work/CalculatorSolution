using Autofac;
using DependencyInjection.Interfaces;
using DependencyInjection.Strategies;
using DependencyInjection.Strategies.Interfaces;

namespace DependencyInjection.Adapters;

public sealed class AutofacContainerAdapterBuilderSingletonSupport : IDependencyRegistrarSingletonSupport
{
    private readonly AutofacContainerAdapter.BuilderSupportData _data;

    private AutofacContainerAdapterBuilderSingletonSupport(AutofacContainerAdapter.BuilderSupportData data) =>
        _data = data;

    public static IDependencyRegistrarSingletonSupport Create(AutofacContainerAdapter.BuilderSupportData data) =>
        new AutofacContainerAdapterBuilderSingletonSupport(data);

    public IDependencyRegistrarOrBuild RegisterSingleton<TService>(
        Func<IDependencyProvider, TService> factory
    ) where TService : class
    {
        var adaptee = _data.Adaptee;

        adaptee.Register(context => factory(_data.UpdateProvider(context))).SingleInstance();

        return _data.UpdateRegistrar(adaptee);
    }
}