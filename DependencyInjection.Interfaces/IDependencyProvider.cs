namespace DependencyInjection.Interfaces;

public interface IDependencyProvider
{
    public TService Resolve<TService>() where TService : notnull;
}