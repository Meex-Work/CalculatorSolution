using System.Reflection;
using Calculator.Events.Abstracts;

namespace Tests.Unit.Interfaces;

public interface ITestArrangeBuilder<out TEvent>
    where TEvent : CalculatorEvent
{
    public TEvent SetToStart();
    public TEvent SetToFirstNumber();
    public TEvent SetToFirstNumberDecimal();
    public TEvent SetToOperator();
    public TEvent SetToSecondNumber();
    public TEvent SetToSecondNumberDecimal();
    public TEvent SetToResult();

    public static readonly IEnumerable<Func<ITestArrangeBuilder<TEvent>, Func<TEvent>>> List = InternalList();

    private static IEnumerable<Func<ITestArrangeBuilder<TEvent>, Func<TEvent>>> InternalList() =>
        typeof(ITestArrangeBuilder<TEvent>)
            .GetMethods()
            .Where(info => info.ReturnType == typeof(TEvent))
            .Select(StateFunc);

    private static Func<ITestArrangeBuilder<TEvent>, Func<TEvent>> StateFunc(MethodInfo info) =>
        state => (Func<TEvent>)(() => (TEvent)info.Invoke(state, null)!);
}