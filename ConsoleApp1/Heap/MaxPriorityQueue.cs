namespace ConsoleApp1.Heap;
public class MaxPriorityQueue<TElement, TPriority> : PriorityQueue<TElement, TPriority>
    where TPriority : struct, IComparable<TPriority>
{
    public MaxPriorityQueue(int initialCapacity) : base(initialCapacity, new MaxPriorityQueueNumberComparer<TPriority>())
    {

    }

    public MaxPriorityQueue(IEnumerable<(TElement Element, TPriority Priority)> items) : base(items, new MaxPriorityQueueNumberComparer<TPriority>())
    {
    }

    public MaxPriorityQueue() : base(new MaxPriorityQueueNumberComparer<TPriority>())
    {

    }

    private class MaxPriorityQueueNumberComparer<T> : IComparer<T> where T : struct, IComparable<T>
    {
        public int Compare(T x, T y)
        {
            return y.CompareTo(x);
        }
    }
}