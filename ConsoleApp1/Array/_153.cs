namespace ConsoleApp1.Array;

public class _153
{
    public int FindMin(int[] nums, int start = 0, int end = -1)
    {
        if (end == -1)
        {
            end = nums.Length - 1;
        }
        if (nums[start] <= nums[end])
        {
            return nums[start];
        }

        var middleEleIndex = (start + end) / 2;
        if (nums[end] > nums[middleEleIndex])
        {
            return FindMin(
                nums,
                start,
                middleEleIndex);
        }
        return FindMin(
            nums,
            middleEleIndex + 1,
            end);
    }
}