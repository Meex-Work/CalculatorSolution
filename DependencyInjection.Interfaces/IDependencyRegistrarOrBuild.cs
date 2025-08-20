namespace DependencyInjection.Interfaces;

public interface IDependencyRegistrarOrBuild :
    IDependencyRegistrar,
    IDependencyContainerBuild;