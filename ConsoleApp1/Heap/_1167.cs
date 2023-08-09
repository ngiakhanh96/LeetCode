namespace ConsoleApp1.Heap;

public class _1167
{
    public int ConnectSticks(int[] sticks)
    {
        var minHeap = new PriorityQueue<int, int>(sticks.Length);
        foreach (var stick in sticks)
        {
            minHeap.Enqueue(stick);
        }

        var cost = 0;
        while (minHeap.Count > 1)
        {
            var smallestStick = minHeap.Dequeue();
            var secondSmallestStick = minHeap.Dequeue();
            cost += smallestStick + secondSmallestStick;
            minHeap.Enqueue(smallestStick + secondSmallestStick);
        }

        return cost;
    }
}