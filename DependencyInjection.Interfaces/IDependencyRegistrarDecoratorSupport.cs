namespace DependencyInjection.Interfaces;

public interface IDependencyRegistrarDecoratorSupport
{
    public IDependencyRegistrarOrBuild RegisterDecorator<TService>(Func<IDependencyProvider, TService, TService> factory)
        where TService : class;
}