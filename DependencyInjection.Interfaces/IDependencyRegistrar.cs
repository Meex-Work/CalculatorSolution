namespace DependencyInjection.Interfaces;

public interface IDependencyRegistrar :
    IDependencyRegistrarDecoratorSupport,
    IDependencyRegistrarCompositeSupport,
    IDependencyRegistrarStrategySupport,
    IDependencyRegistrarSingletonSupport,
    IDependencyRegistrarAdapterSupport
{
    public IDependencyRegistrarOrBuild Register<TService>(Func<IDependencyProvider, TService> factory)
        where TService : notnull;
}