namespace ConsoleApp1.Deque;

[LastVisited(2022, 11, 9)]
public class _239
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        var st = new Stack<int>();
        var deque = new LinkedList<int[]>();
        var result = new int[nums.Length - (k - 1)];
        var count = 0;
        var resultCount = 0;
        do
        {
            if (deque.First != null && deque.First.Value[1] <= count - k)
            {
                deque.RemoveFirst();
            }
            while (deque.Last != null && deque.Last.Value[0] < nums[count])
            {
                deque.RemoveLast();
            }
            deque.AddLast(new int[] { nums[count], count });
            if (count >= k - 1)
            {
                result[resultCount++] = deque.First.Value[0];
            }
            count++;
        } while (resultCount < result.Length);
        return result;
    }

    public int[] MaxSlidingWindow2(int[] nums, int k)
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
    public int[] MaxSlidingWindow3(int[] nums, int k)
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