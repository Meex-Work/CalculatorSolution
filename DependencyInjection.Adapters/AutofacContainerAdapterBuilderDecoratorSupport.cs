using Autofac;
using DependencyInjection.Interfaces;

namespace DependencyInjection.Adapters;

public sealed class AutofacContainerAdapterBuilderDecoratorSupport : IDependencyRegistrarDecoratorSupport
{
    private readonly AutofacContainerAdapter.BuilderSupportData _data;

    private AutofacContainerAdapterBuilderDecoratorSupport(AutofacContainerAdapter.BuilderSupportData data) =>
        _data = data;

    public static IDependencyRegistrarDecoratorSupport Create(AutofacContainerAdapter.BuilderSupportData data) =>
        new AutofacContainerAdapterBuilderDecoratorSupport(data);

    public IDependencyRegistrarOrBuild RegisterDecorator<TService>(
        Func<IDependencyProvider, TService, TService> factory
    ) where TService : class
    {
        var adaptee = _data.Adaptee;

        adaptee.RegisterDecorator<TService>((
                context,
                _,
                service
            ) => factory(
                _data.UpdateProvider(context),
                service
            )
        );

        return _data.UpdateRegistrar(adaptee);
    }
}