namespace ConsoleApp1.Array;

public class _523
{
    public bool CheckSubarraySum(int[] nums, int k)
    {
        var currentSum = 0;
        var hashSet = new HashSet<int>();
        var queue = new Queue<int>(new int[] { 0 });
        for (int i = 0; i < nums.Length; i++)
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