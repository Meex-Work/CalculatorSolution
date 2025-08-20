using DependencyInjection.Adapters;
using DependencyInjection.Interfaces;

namespace DependencyInjection;

public static class DependencyContainer
{
    public static IDependencyContainerBuilder Create() => AutofacContainerAdapter.Builder();
}
    