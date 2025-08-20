namespace DependencyInjection.Interfaces;

public interface IDependencyRegistrarAdapterSupport
{
    public IDependencyRegistrarOrBuild RegisterAdapter<TService, TAdapter>(
        Func<IDependencyProvider, TService, TAdapter> factory)
        where TAdapter : notnull
        where TService : notnull;
}