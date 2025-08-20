namespace DependencyInjection.Strategies.Interfaces;

public interface IStrategy<in TContext, out TTarget>
{
    public TTarget Get(TContext context);
}