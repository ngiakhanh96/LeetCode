namespace ConsoleApp1.PrefixSum;

public class _53
{
    public int MaxSubArray(int[] array)
    {
        var count = 0;
        var minValue = 0;
        var maxSum = int.MinValue;
        for (int i = 0; i < array.Length; i++)
        {
            count += array[i];
            var currentMaxSum = count - minValue;
            maxSum =
                maxSum > currentMaxSum
                    ? maxSum
                    : currentMaxSum;
            minValue = minValue < count ? minValue : count;
        }

        return maxSum;
    }

    public int MaxSubArray2(int[] nums)
    {
        int maxSum = nums[0];
        int currentMax = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            currentMax = Math.Max(nums[i], currentMax + nums[i]);
            maxSum = Math.Max(maxSum, currentMax);
        }
        return maxSum;
    }
}