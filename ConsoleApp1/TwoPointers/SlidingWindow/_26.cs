namespace ConsoleApp1.TwoPointers.SlidingWindow;

public class _26
{
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }
        var firstPointer = 0;
        var secondPointer = 0;
        var k = 1;
        while (secondPointer < nums.Length)
        {
            if (nums[secondPointer] != nums[firstPointer])
            {
                k++;
                firstPointer++;
                nums[firstPointer] = nums[secondPointer];
            }
            secondPointer++;
        }
        return k;
    }
}