namespace ConsoleApp1.TwoPointers.SlidingWindow;

public class _674
{
    public int FindLengthOfLCIS(int[] nums)
    {
        var firstPointer = 0;
        var secondPointer = 0;
        var longestIncreasingSubArray = 1;
        while (secondPointer < nums.Length)
        {
            longestIncreasingSubArray = Math.Max(longestIncreasingSubArray, secondPointer - firstPointer + 1);
            if (secondPointer < nums.Length - 1 && nums[secondPointer] >= nums[secondPointer + 1])
            {
                firstPointer = secondPointer + 1;
            }
            secondPointer++;
        }

        return longestIncreasingSubArray;
    }
}