using Calculator.Commands.DependencyInjection;
using Calculator.Events.DependencyInjection;
using Calculator.Queries.DependencyInjection;
using Calculator.Services.DependencyInjection;
using Calculator.States.DependencyInjection;
using Calculator.Utils.Dependencies;
using DependencyInjection.Interfaces;

namespace DependencyInjection;

public static class Factory
{
    public static IDependencyProvider Build() => DependencyContainer
        .Create()
        .RegisterUtils()
        .RegisterEvents()
        .RegisterServices()
        .RegisterStates()
        .RegisterQueries()
        .RegisterCommands()
        .Build();
}