namespace ConsoleApp1.Array;

public static class PriorityQueueExtensions
{
    public static void Enqueue<T>(this PriorityQueue<T, T> pq, T value)
    {
        pq.Enqueue(value, value);
    }

    public static T EnqueueDequeue<T>(this PriorityQueue<T, T> pq, T value)
    {
        pq.Enqueue(value);
        return pq.Dequeue();
    }

    public static T DequeueEnqueue<T>(this PriorityQueue<T, T> pq, T value)
    {
        var res = pq.Dequeue();
        pq.Enqueue(value);
        return res;
    }
}