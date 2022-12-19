namespace ConsoleApp1.BinarySearch;

[LastVisited(2022, 12, 20)]
public class _154
{
    public int FindMin(int[] nums)
    {
        var low = 0;
        var high = nums.Length - 1;
        while (low < high)
        {
            if (nums[low] == nums[high])
            {
                low++;
                continue;
            }

            var middle = low + (high - low) / 2;
            if (nums[low] > nums[high])
            {
                if (nums[middle] >= nums[low])
                {
                    low = middle + 1;
                }
                else
                {
                    high = middle;
                }
            }
            else
            {
                high = middle;
            }
        }

        return nums[low];
    }

    public int FindMin2(int[] nums)
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

            while (low < nums.Length - 1 && nums[low] == nums[low + 1])
            {
                low++;
            }
            while (high > 0 && nums[high] == nums[high - 1])
            {
                high--;
            }
        }

        return nums[low];
    }
}