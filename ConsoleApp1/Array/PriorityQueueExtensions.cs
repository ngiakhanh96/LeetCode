namespace ConsoleApp1.Array;

public static class PriorityQueueExtensions
{
    public static void Enqueue<T>(this PriorityQueue<T, T> pq, T value)
    {
        pq.Enqueue(value, value);
    }
}