namespace ConsoleApp1.Array;

public class _485
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        var firstPointer = 0;
        var secondPointer = 0;
        var k = 0;
        while (secondPointer < nums.Length)
        {
            while (secondPointer < nums.Length && nums[secondPointer] == 0)
            {
                secondPointer++;
            }

            firstPointer = secondPointer;
            while (secondPointer < nums.Length && nums[secondPointer] == 1)
            {
                secondPointer++;
            }

            k = Math.Max(k, secondPointer - firstPointer);
        }
        return k;
    }
}