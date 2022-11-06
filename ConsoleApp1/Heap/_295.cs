namespace ConsoleApp1.Heap;

//Cannot solve because Leetcode not use .net 6
public class _295
{
    public class MedianFinder
    {
        public MaxHeap MaxHeap { get; set; } = new MaxHeap(50000);

        public MinHeap MinHeap { get; set; } = new MinHeap(50000);

        public void AddNum(int num)
        {
            if (MaxHeap.Count == MinHeap.Count)
            {
                if (MaxHeap.IsEmpty() || num <= MaxHeap.Peek())
                {
                    MaxHeap.Add(num);
                }
                else
                {
                    MinHeap.Add(num);
                    MaxHeap.Add(MinHeap.Pop());

                }
            }
            else
            {
                if (!MinHeap.IsEmpty() && num >= MinHeap.Peek())
                {
                    MinHeap.Add(num);
                }
                else
                {
                    MaxHeap.Add(num);
                    MinHeap.Add(MaxHeap.Pop());
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
        public PriorityQueue<int, int> MinHeap { get; set; } = new PriorityQueue<int, int>();

        public PriorityQueue<int, int> MaxHeap { get; set; } = new PriorityQueue<int, int>(new MaxHeapIntComparer());

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