namespace ConsoleApp1.Heap;

public class _1753
{
    public int MaximumScore(int a, int b, int c)
    {
        var maxHeap = new MaxHeap(3);
        maxHeap.Add(a);
        maxHeap.Add(b);
        maxHeap.Add(c);

        var res = 0;
        while (true)
        {
            var largest = maxHeap.Pop();
            var secondLargest = maxHeap.Pop();

            if (largest == 0 && secondLargest == 0)
            {
                break;
            }

            res++;
            maxHeap.Add(--largest);
            maxHeap.Add(--secondLargest);
        }
        return res;
    }

    public int MaximumScore2(int a, int b, int c)
    {
        var maxHeap = new PriorityQueue<int, int>(3, new MaxHeapComparer());
        maxHeap.Enqueue(a);
        maxHeap.Enqueue(b);
        maxHeap.Enqueue(c);

        var res = 0;
        while (true)
        {
            var largest = maxHeap.Dequeue();
            var secondLargest = maxHeap.Dequeue();

            if (largest == 0 && secondLargest == 0)
            {
                break;
            }

            res++;
            maxHeap.Enqueue(--largest);
            maxHeap.Enqueue(--secondLargest);
        }
        return res;
    }
}