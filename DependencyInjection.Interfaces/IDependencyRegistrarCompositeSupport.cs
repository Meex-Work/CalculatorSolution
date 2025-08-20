namespace DependencyInjection.Interfaces;

public interface IDependencyRegistrarCompositeSupport
{
    public IDependencyRegistrarOrBuild RegisterComposite<TService>(Func<IDependencyProvider, IEnumerable<TService>, TService> factory)
        where TService : class;
}