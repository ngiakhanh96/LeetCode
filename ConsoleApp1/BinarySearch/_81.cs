namespace ConsoleApp1.BinarySearch;

[LastVisited(2022, 12, 20)]
public class _81
{
    public bool Search(int[] nums, int target)
    {
        var low = 0;
        var high = nums.Length - 1;
        while (low <= high)
        {
            if (nums[low] == nums[high])
            {
                if (nums[low] == target)
                {
                    return true;
                }
                low++;
                high--;
                continue;
            }

            var middle = low + (high - low) / 2;
            if (nums[middle] == target || nums[low] == target || nums[high] == target)
            {
                return true;
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

        return false;
    }

    public bool Search2(int[] nums, int target)
    {
        var low = 0;
        var high = nums.Length - 1;
        while (low < nums.Length - 1 && nums[low] == nums[low + 1])
        {
            low++;
        }
        while (high > 0 && nums[high] == nums[high - 1])
        {
            high--;
        }
        while (low <= high)
        {
            var middle = low + (high - low) / 2;
            if (nums[middle] == target)
            {
                return true;
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
            while (low < nums.Length - 1 && nums[low] == nums[low + 1])
            {
                low++;
            }

            while (high > 0 && nums[high] == nums[high - 1])
            {
                high--;
            }
        }

        if (low < nums.Length && nums[low] == target)
        {
            return true;
        }

        return false;
    }
}