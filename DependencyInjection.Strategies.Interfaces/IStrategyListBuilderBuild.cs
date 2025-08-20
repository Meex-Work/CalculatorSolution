namespace DependencyInjection.Strategies.Interfaces;

public interface IStrategyListBuilderBuild<in TContext, out TTarget>
    where TContext : notnull
{
    public IStrategyList<TContext, TTarget> Build();
}