namespace ConsoleApp1.Heap;

public static class PriorityQueueExtensions
{
    public static void Enqueue<T>(this PriorityQueue<T, T> pq, T value)
    {
        pq.Enqueue(value, value);
    }

    public static T EnqueueDequeue<T>(this PriorityQueue<T, T> pq, T value)
    {
        return pq.EnqueueDequeue(value, value);
    }

    public static void DequeueEnqueue<T>(this PriorityQueue<T, T> pq, T value)
    {
        pq.Dequeue();
        pq.Enqueue(value);
    }
}