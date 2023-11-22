namespace ConsoleApp1.TwoPointers.SameDirection;

[LastVisited(2023, 01, 02)]
public class _26
{
    public int RemoveDuplicates(int[] nums)
    {
        var firstPointer = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (firstPointer == 0 || nums[i] != nums[firstPointer - 1])
            {
                nums[firstPointer] = nums[i];
                firstPointer++;
            }
        }

        return firstPointer;

    }

    public int RemoveDuplicates2(int[] nums)
    {
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