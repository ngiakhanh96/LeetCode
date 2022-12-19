namespace ConsoleApp1.BinarySearch;

[LastVisited(2022, 12, 13)]
public class _33
{
    public int Search(int[] nums, int target)
    {
        var low = 0;
        var high = nums.Length - 1;
        while (low <= high)
        {
            var middle = low + (high - low + 1) / 2;
            if (nums[middle] == target)
            {
                return middle;
            }

            if (nums[middle] < target)
            {
                if (nums[middle] <= nums[high] && target >= nums[low] && nums[low] > nums[high])
                {
                    high = middle - 1;
                }
                else
                {
                    low = middle + 1;
                }
            }
            else
            {
                if (nums[middle] >= nums[low] && target <= nums[high] && nums[low] > nums[high])
                {
                    low = middle + 1;
                }
                else
                {
                    high = middle - 1;
                }
            }
        }

        return -1;
    }

    public int Search2(int[] nums, int target)
    {
        var low = 0;
        var high = nums.Length - 1;

        while (low <= high)
        {
            var middle = low + (high - low) / 2;
            if (nums[middle] == target)
            {
                return middle;
            }

            if (nums[high] > nums[low])
            {
                if (nums[middle] < target)
                {
                    low = middle + 1;
                }
                else
                {
                    high = middle - 1;
                }
            }
            else
            {
                // Right branch
                if (nums[middle] < nums[high])
                {
                    if (target > nums[middle] && target <= nums[high])
                    {
                        low = middle + 1;
                    }
                    else
                    {
                        high = middle - 1;
                    }
                }

                // Left branch
                else
                {
                    if (target < nums[middle] && target >= nums[low])
                    {
                        high = middle - 1;
                    }
                    else
                    {
                        low = middle + 1;
                    }
                }
            }
        }

        return -1;
    }
}