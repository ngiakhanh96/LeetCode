namespace ConsoleApp1.Array;

public class _153
{
    public int FindMin(int[] nums)
    {
        var startIndex = 0;
        var endIndex = nums.Length - 1;
        while (startIndex < endIndex)
        {
            var middleIndex = (startIndex + endIndex) / 2;
            var rightMost = nums[endIndex];
            var middlePivot = nums[middleIndex];

            if (rightMost > middlePivot)
            {
                endIndex = middleIndex;
            }
            else
            {
                startIndex = middleIndex + 1;
            }
        }

        if (startIndex == endIndex)
        {
            return nums[startIndex];
        }
        return -1;
    }

    public int FindMin2(int[] nums, int start = 0, int end = -1)
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
            return FindMin2(
                nums,
                start,
                middleEleIndex);
        }
        return FindMin2(
            nums,
            middleEleIndex + 1,
            end);
    }
}