namespace SignalPoc;

internal static class Signal
{
    public static Action? CurrentEffectSubscription;
    public static ComputedSignalBase? CurrentComputedSignalSubscription;
    public static List<SignalBase> CurrentSignals = [];
    public static SignalEffectSubscription CreateEffect(Action action)
    {
        CurrentEffectSubscription = action;
        action();
        var effectSubscription = new SignalEffectSubscription(CurrentSignals, CurrentEffectSubscription);
        CurrentEffectSubscription = null;
        CurrentSignals = [];
        return effectSubscription;
    }

    public static ComputedSignal<T> ComputeSignal<T>(Func<T> action)
    {
        ComputedSignal<T> computedSignal = new(action);
        return computedSignal;
    }

    public static Signal<T> CreateSignal<T>(T value)
    {
        return new Signal<T>(value);
    }
}

internal record SignalEffectSubscription(List<SignalBase> Signals, Action Action)
{
    public void Unsubscribe()
    {
        foreach (var signal in Signals)
        {
            signal.RemoveEffectSubscription(Action);
        }
    }
}
internal interface IReadOnlySignal<out T>
{
    public T Get();
}

internal abstract class SignalBase
{
    private readonly HashSet<Action> _effectSubscriptions = [];
    private readonly HashSet<ComputedSignalBase> _computedSignals = [];

    public void RemoveEffectSubscription(Action action)
    {
        _effectSubscriptions.Remove(action);
    }

    public void RemoveComputedSignal(ComputedSignalBase computedSignalBase)
    {
        _computedSignals.Remove(computedSignalBase);
    }

    protected void Notify()
    {
        foreach (var subscription in _effectSubscriptions)
        {
            subscription();
        }

        foreach (var signal in _computedSignals)
        {
            signal.MarkObsolete();
        }
    }

    protected void UpdateSubscriptions()
    {
        if (Signal.CurrentEffectSubscription is not null)
        {
            _effectSubscriptions.Add(Signal.CurrentEffectSubscription);
            Signal.CurrentSignals.Add(this);
        }

        else if (Signal.CurrentComputedSignalSubscription is not null)
        {
            _computedSignals.Add(Signal.CurrentComputedSignalSubscription);
            Signal.CurrentSignals.Add(this);
        }
    }
}

internal class Signal<T>(T value) : SignalBase, IReadOnlySignal<T>
{
    public T Get()
    {
        UpdateSubscriptions();
        return value;
    }

    public void Update(Func<T, T> action)
    {
        value = action(value);
        Notify();
    }
}

internal abstract class ComputedSignalBase : SignalBase
{
    protected bool IsObsolete = true;
    protected List<SignalBase> CurrentChildSignals = [];
    public void MarkObsolete()
    {
        IsObsolete = true;
    }

    public void Unsubscribe()
    {
        foreach (var signal in CurrentChildSignals)
        {
            signal.RemoveComputedSignal(this);
        }
    }
}

internal class ComputedSignal<T> : ComputedSignalBase, IReadOnlySignal<T>
{
    private readonly Func<T> _valueFn;
    private T _cacheResult;

    public ComputedSignal(Func<T> valueFn)
    {
        ArgumentNullException.ThrowIfNull(valueFn);
        _valueFn = valueFn;
        Recalculate();
    }

    public T Get()
    {
        UpdateSubscriptions();
        if (IsObsolete)
        {
            Recalculate();
        }
        return _cacheResult;
    }

    private void Recalculate()
    {
        //Unregister old child signals
        Unsubscribe();

        Signal.CurrentComputedSignalSubscription = this;
        _cacheResult = _valueFn();

        //Register new child signals
        CurrentChildSignals = Signal.CurrentSignals;
        Signal.CurrentSignals = [];
        Signal.CurrentComputedSignalSubscription = null;
        IsObsolete = false;

        Notify();
    }
}