namespace ConsoleApp1.TwoPointers.SlidingWindow;

[LastVisited(2022, 12, 28)]
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

    public int FindLengthOfLCIS2(int[] nums)
    {
        var slowPointerIndex = 0;
        var currentLengthOfLCIS = 1;
        var previousNum = nums[slowPointerIndex];
        for (var i = 1; i < nums.Length; i++)
        {
            var currentNum = nums[i];
            if (currentNum <= previousNum)
            {
                slowPointerIndex = i;
            }
            else
            {
                currentLengthOfLCIS = Math.Max(currentLengthOfLCIS, i + 1 - slowPointerIndex);
            }
            previousNum = currentNum;
        }

        return currentLengthOfLCIS;
    }
}