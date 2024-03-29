﻿namespace ConsoleApp1.Queue;

public class _523
{
    public bool CheckSubarraySum(int[] nums, int k)
    {
        var currentSum = 0;
        var hashSet = new HashSet<int>();
        var queue = new Queue<int>(new[] { 0 });
        for (var i = 0; i < nums.Length; i++)
        {
            currentSum += nums[i];
            var smallestPositiveRemainder = (currentSum % k + k) % k;

            if (hashSet.Contains(smallestPositiveRemainder))
            {
                return true;
            }
            queue.Enqueue(smallestPositiveRemainder);
            hashSet.Add(queue.Dequeue());
        }
        return false;
    }
}