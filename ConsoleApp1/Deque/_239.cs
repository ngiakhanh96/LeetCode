namespace ConsoleApp1.Deque;

public class _239
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        var dequeue = new LinkedList<int>();
        var res = new int[nums.Length - (k - 1)];
        var count = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (dequeue.First != null && dequeue.First.Value < i - k + 1)
            {
                dequeue.RemoveFirst();
            }

            var currentValue = nums[i];
            var lastValue = dequeue.Last?.Value;
            while (lastValue != null && nums[(int)lastValue] < currentValue)
            {
                dequeue.RemoveLast();
                lastValue = dequeue.Last?.Value;
            }

            dequeue.AddLast(i);

            if (i >= k - 1)
            {
                res[count++] = nums[dequeue.First.Value];
            }
        }

        return res;
    }
    public int[] MaxSlidingWindow2(int[] nums, int k)
    {
        var resArr = new int[nums.Length - k + 1];
        var deque = new LinkedList<int>();
        var tempQueue = new Queue<int>();
        for (var i = 0; i < nums.Length; i++)
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