namespace SignalPoc;

internal static class SignalOop
{
    public static Action? CurrentSubscription;
    public static List<SignalBase> CurrentSignals = [];
    public static SignalSubscription CreateEffect(Action action)
    {
        CurrentSubscription = action;
        action();
        var currentSignals = new SignalSubscription(CurrentSignals, CurrentSubscription);
        CurrentSubscription = null;
        CurrentSignals = [];
        return currentSignals;
    }

    public static (Signal<T?> Signal, SignalSubscription Subscription) ComputeSignal<T>(Func<T> action)
    {
        Signal<T?> computedSignal = new(default);
        var subscription = CreateEffect(() =>
        {
            var value = action();
            computedSignal.Update(val => value);
        });
        return (computedSignal, subscription);
    }

    public static Signal<T> CreateSignal<T>(T value)
    {
        return new Signal<T>(value);
    }
}

internal record SignalSubscription(List<SignalBase> Signals, Action Action)
{
    public void Unsubscribe()
    {
        foreach (var signal in Signals)
        {
            signal.RemoveSubscription(Action);
        }
    }
}

internal abstract class SignalBase
{
    protected readonly HashSet<Action> Subscriptions = [];

    public void RemoveSubscription(Action action)
    {
        Subscriptions.Remove(action);
    }
}

internal class Signal<T>(T value) : SignalBase
{
    public T Get()
    {
        if (SignalOop.CurrentSubscription is not null)
        {
            Subscriptions.Add(SignalOop.CurrentSubscription);
            SignalOop.CurrentSignals.Add(this);
        }

        return value;
    }

    public void Update(Func<T, T> action)
    {
        value = action(value);
        foreach (var subscription in Subscriptions)
        {
            subscription();
        }
    }
}