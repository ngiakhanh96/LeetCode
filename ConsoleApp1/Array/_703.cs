namespace ConsoleApp1.Array;

public class _703
{
    public class KthLargest
    {
        public MinHeap MinHeap { get; set; }
        public KthLargest(int k, int[] nums)
        {
            MinHeap = new MinHeap(k);
            foreach (var num in nums)
            {
                AddToHeap(num);
            }

        }

        private void AddToHeap(int num)
        {
            if (!MinHeap.IsFull())
            {
                MinHeap.Add(num);
            }
            else
            {
                var currentSmallest = MinHeap.Peek();
                if (num > currentSmallest)
                {
                    MinHeap.Pop();
                    MinHeap.Add(num);
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
        public PriorityQueue<int, int> MinHeap { get; set; } = new PriorityQueue<int, int>();
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
                    MinHeap.Dequeue();
                    MinHeap.Enqueue(num);
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