namespace ConsoleApp1.Heap;

public class _703
{
    public class KthLargest
    {
        public PriorityQueue<int, int> MinHeap { get; set; }

        public int Size { get; set; }

        public KthLargest(int k, int[] nums)
        {
            Size = k;
            MinHeap = new();
            foreach (var num in nums)
            {
                AddToHeap(num);
            }

        }

        private void AddToHeap(int num)
        {
            if (MinHeap.Count < Size)
            {
                MinHeap.Enqueue(num);
            }
            else
            {
                var currentSmallest = MinHeap.Peek();
                if (num > currentSmallest)
                {
                    MinHeap.DequeueEnqueue(num);
                }
            }
        }

        public int Add(int val)
        {
            AddToHeap(val);
            return MinHeap.Peek();
        }
    }

    public class KthLargest2
    {
        public PriorityQueue<int, int> MinHeap { get; set; } = new();
        public KthLargest2(int k, int[] nums)
        {
            foreach (var num in nums)
            {
                AddToHeap(num, k);
            }

        }

        private void AddToHeap(int num, int k)
        {
            if (MinHeap.Count < k)
            {
                MinHeap.Enqueue(num);
            }
            else
            {
                var currentSmallest = MinHeap.Peek();
                if (num > currentSmallest)
                {
                    MinHeap.DequeueEnqueue(num);
                }
            }
        }

        public int Add(int val, int k)
        {
            AddToHeap(val, k);
            return MinHeap.Peek();
        }
    }
}