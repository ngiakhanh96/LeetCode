namespace ConsoleApp1.Array;

//Cannot solve because Leetcode not use .net 6
public class _295
{
    public class MedianFinder
    {
        public IHeap LeftHeap { get; set; }

        public IHeap RightHeap { get; set; }

        public List<int> Temp { get; set; } = new List<int>();
        public MedianFinder()
        {

        }

        public void AddNum(int num)
        {
            if (Temp != null)
            {
                Temp.Add(num);
                if (Temp.Count > 1)
                {
                    if (Temp[0] > Temp[1])
                    {
                        LeftHeap = new MinHeap(1000);
                        RightHeap = new MaxHeap(1000);
                    }
                    else
                    {
                        LeftHeap = new MaxHeap(1000);
                        RightHeap = new MinHeap(1000);
                    }

                    AddHeap(Temp[0]);
                    AddHeap(Temp[1]);
                    Temp = null;
                }
            }
            else
            {
                AddHeap(num);
            }
        }

        private void AddHeap(int val)
        {
            if (LeftHeap.Count == RightHeap.Count)
            {
                if (!RightHeap.IsEmpty())
                {
                    LeftHeap.Add(RightHeap.Pop());
                    RightHeap.Add(val);
                }
                else
                {
                    LeftHeap.Add(val);
                }
            }
            else
            {
                RightHeap.Add(val);
            }
        }

        public double FindMedian()
        {
            if (Temp != null)
            {
                return Temp[0];
            }
            if (LeftHeap.Count > RightHeap.Count)
            {
                return LeftHeap.Peek();
            }

            return ((double)LeftHeap.Peek() + RightHeap.Peek()) / 2;
        }
    }

    public class MedianFinder2
    {
        public PriorityQueue<int, int> MinHeap { get; set; } = new PriorityQueue<int, int>();

        public PriorityQueue<int, int> MaxHeap { get; set; } = new PriorityQueue<int, int>(new MaxHeapComparer());
        public MedianFinder2()
        {

        }

        public void AddNum(int num)
        {
            if (MaxHeap.Count == MinHeap.Count)
            {
                if (MinHeap.Count > 0)
                {
                    MaxHeap.Enqueue(MinHeap.Dequeue());
                }

                MaxHeap.Enqueue(num);
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