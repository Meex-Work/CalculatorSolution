using Autofac;
using DependencyInjection.Interfaces;

namespace DependencyInjection.Adapters;

public sealed class AutofacContainerAdapterBuilderAdapterSupport : IDependencyRegistrarAdapterSupport
{
    private readonly AutofacContainerAdapter.BuilderSupportData _data;

    private AutofacContainerAdapterBuilderAdapterSupport(AutofacContainerAdapter.BuilderSupportData data) =>
        _data = data;

    public static IDependencyRegistrarAdapterSupport Create(AutofacContainerAdapter.BuilderSupportData data) =>
        new AutofacContainerAdapterBuilderAdapterSupport(data);

    public IDependencyRegistrarOrBuild RegisterAdapter<TService, TAdapter>(
        Func<IDependencyProvider, TService, TAdapter> factory
    ) where TService : notnull
        where TAdapter : notnull
    {
        var adaptee = _data.Adaptee;

        adaptee.RegisterAdapter<TService, TAdapter>((
                context,
                service
            ) => factory(
                _data.UpdateProvider(context),
                service)
        );

        return _data.UpdateRegistrar(adaptee);
    }
}