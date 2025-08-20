namespace DependencyInjection.Interfaces;

public interface IDependencyRegistrarSingletonSupport
{
    public IDependencyRegistrarOrBuild RegisterSingleton<TService>(Func<IDependencyProvider, TService> factory)
        where TService : class;
}