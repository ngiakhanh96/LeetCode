namespace ConsoleApp1.BinarySearch;

[LastVisited(2022, 12, 20)]
public class _153
{
    public int FindMin(int[] nums)
    {
        var low = 0;
        var high = nums.Length - 1;

        while (low < high)
        {
            var middle = low + (high - low) / 2;
            if (nums[high] > nums[low])
            {
                high = low;
            }
            else
            {
                // Right branch
                if (nums[middle] < nums[high])
                {
                    high = middle;
                }

                // Left branch
                else
                {
                    low = middle + 1;
                }
            }
        }

        return nums[low];
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