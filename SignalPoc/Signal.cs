namespace SignalPoc;

internal static class Signal
{
    public static Action? CurrentEffectSubscription;
    public static ComputedSignalBase? CurrentComputedSignal;
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

    public static ComputedSignal<T> Computed<T>(Func<T> action)
    {
        ComputedSignal<T> computedSignal = new(action);
        return computedSignal;
    }

    public static Signal<T> Create<T>(T value)
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
    private readonly HashSet<WeakReference<ComputedSignalBase>> _computedChildSignals = [];

    public void RemoveEffectSubscription(Action action)
    {
        _effectSubscriptions.Remove(action);
    }

    public void RemoveChildComputedSignal(ComputedSignalBase computedSignalBase)
    {
        UpdateComputedChildSignals(orFilter: signal => signal == computedSignalBase);
    }

    protected void Notify()
    {
        foreach (var subscription in _effectSubscriptions)
        {
            subscription();
        }

        UpdateComputedChildSignals(action: signal =>
        {
            signal.MarkObsolete();
            signal.Notify();
        });
    }

    protected void UpdateSubscriptions()
    {
        if (Signal.CurrentEffectSubscription is not null)
        {
            _effectSubscriptions.Add(Signal.CurrentEffectSubscription);
            Signal.CurrentSignals.Add(this);
        }

        else if (Signal.CurrentComputedSignal is not null)
        {
            _computedChildSignals.Add(new WeakReference<ComputedSignalBase>(Signal.CurrentComputedSignal));
            Signal.CurrentSignals.Add(this);
        }
    }

    private void UpdateComputedChildSignals(Action<ComputedSignalBase>? action = null, Predicate<ComputedSignalBase>? orFilter = null)
    {
        _computedChildSignals.RemoveWhere(ccs =>
        {
            if (ccs.TryGetTarget(out var signal))
            {
                if (orFilter is not null && orFilter(signal))
                {
                    return true;
                }
                action?.Invoke(signal);
                return false;
            }
            return true;
        });
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
    protected List<SignalBase> CurrentParentSignals = [];
    public void MarkObsolete()
    {
        IsObsolete = true;
    }

    public void Unsubscribe()
    {
        foreach (var signal in CurrentParentSignals)
        {
            signal.RemoveChildComputedSignal(this);
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
        //Unregister old parent signals
        Unsubscribe();

        Signal.CurrentComputedSignal = this;
        _cacheResult = _valueFn();

        //Register new parent signals
        CurrentParentSignals = Signal.CurrentSignals;
        Signal.CurrentSignals = [];
        Signal.CurrentComputedSignal = null;
        IsObsolete = false;
    }
}