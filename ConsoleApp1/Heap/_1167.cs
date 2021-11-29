namespace ConsoleApp1.Heap;

public class _1167
{
    public int ConnectSticks(int[] sticks)
    {
        var minHeap = new MinHeap(sticks.Length);
        foreach (var stick in sticks)
        {
            minHeap.Add(stick);
        }

        var cost = 0;
        while (minHeap.Count > 1)
        {
            var smallestStick = minHeap.Pop();
            var secondSmallestStick = minHeap.Pop();
            cost += smallestStick + secondSmallestStick;
            minHeap.Add(smallestStick + secondSmallestStick);
        }

        return cost;
    }

    public int ConnectSticks2(int[] sticks)
    {
        var minHeap = new PriorityQueue<int, int>();
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