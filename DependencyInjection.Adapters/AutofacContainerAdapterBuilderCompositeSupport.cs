using Autofac;
using DependencyInjection.Interfaces;

namespace DependencyInjection.Adapters;

public sealed class AutofacContainerAdapterBuilderCompositeSupport : IDependencyRegistrarCompositeSupport
{
    private readonly AutofacContainerAdapter.BuilderSupportData _data;

    private AutofacContainerAdapterBuilderCompositeSupport(AutofacContainerAdapter.BuilderSupportData data) =>
        _data = data;

    public static IDependencyRegistrarCompositeSupport Create(AutofacContainerAdapter.BuilderSupportData data) =>
        new AutofacContainerAdapterBuilderCompositeSupport(data);

    public IDependencyRegistrarOrBuild RegisterComposite<TService>(
        Func<IDependencyProvider, IEnumerable<TService>, TService> factory
    ) where TService : class
    {
        var adaptee = _data.Adaptee;
        adaptee.RegisterComposite<TService>((
                context,
                services
            ) => factory(
                _data.UpdateProvider(context),
                services
            )
        );
        return _data.UpdateRegistrar(adaptee);
    }
}