namespace ConsoleApp1.Heap;

public class _295
{
    public class MedianFinder
    {
        public MaxPriorityQueue<int, int> MaxHeap { get; set; } = new(50000);

        public PriorityQueue<int, int> MinHeap { get; set; } = new(50000);

        public void AddNum(int num)
        {
            if (MaxHeap.Count == MinHeap.Count)
            {
                if (MaxHeap.Count == 0 || num <= MaxHeap.Peek())
                {
                    MaxHeap.Enqueue(num);
                }
                else
                {
                    MinHeap.Enqueue(num);
                    MaxHeap.Enqueue(MinHeap.Dequeue());

                }
            }
            else
            {
                if (MinHeap.Count > 0 && num >= MinHeap.Peek())
                {
                    MinHeap.Enqueue(num);
                }
                else
                {
                    MaxHeap.Enqueue(num);
                    MinHeap.Enqueue(MaxHeap.Dequeue());
                }
            }
        }

        public double FindMedian()
        {
            if (MaxHeap.Count > MinHeap.Count)
            {
                return MaxHeap.Peek();
            }

            return ((double)MaxHeap.Peek() + MinHeap.Peek()) / 2;
        }
    }

    public class MedianFinder2
    {
        public PriorityQueue<int, int> MinHeap { get; set; } = new();

        public MaxPriorityQueue<int, int> MaxHeap { get; set; } = new();

        public void AddNum(int num)
        {
            if (MaxHeap.Count == MinHeap.Count)
            {
                if (MaxHeap.Count == 0 || num <= MaxHeap.Peek())
                {
                    MaxHeap.Enqueue(num);
                }
                else
                {
                    MaxHeap.Enqueue(MinHeap.EnqueueDequeue(num));
                }
            }
            else
            {
                if (MinHeap.Count > 0 && num >= MinHeap.Peek())
                {
                    MinHeap.Enqueue(num);
                }
                else
                {
                    MinHeap.Enqueue(MaxHeap.EnqueueDequeue(num));
                }
            }
        }

        public double FindMedian()
        {
            if (MaxHeap.Count > MinHeap.Count)
            {
                return MaxHeap.Peek();
            }

            return ((double)MaxHeap.Peek() + MinHeap.Peek()) / 2;
        }
    }
}