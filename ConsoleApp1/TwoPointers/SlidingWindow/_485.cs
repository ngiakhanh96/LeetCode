namespace ConsoleApp1.TwoPointers.SlidingWindow;

public class _485
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        var secondPointer = 0;
        var k = 0;
        while (secondPointer < nums.Length)
        {
            while (secondPointer < nums.Length && nums[secondPointer] == 0)
            {
                secondPointer++;
            }

            var firstPointer = secondPointer;
            while (secondPointer < nums.Length && nums[secondPointer] == 1)
            {
                secondPointer++;
            }

            k = Math.Max(k, secondPointer - firstPointer);
        }
        return k;
    }
}