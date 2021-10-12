using System.Collections.Generic;

namespace ConsoleApp1.Deque
{
    public class _239
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            var resArr = new int[nums.Length - k + 1];
            var deque = new LinkedList<int>();
            var tempQueue = new Queue<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (tempQueue.Count == k)
                {
                    if (deque.Count > 0 && deque.First.Value == tempQueue.Peek())
                    {
                        deque.RemoveFirst();
                    }

                    tempQueue.Dequeue();
                }

                while (deque.Count > 0 && deque.Last.Value < nums[i])
                {
                    deque.RemoveLast();
                }
                deque.AddLast(nums[i]);
                tempQueue.Enqueue(nums[i]);

                if (tempQueue.Count == k)
                {
                    resArr[i - k + 1] = deque.First.Value;
                }
            }

            return resArr;
        }
    }
}
