namespace ConsoleApp1.BinarySearch;

public class _81
{
    public bool Search(int[] nums, int target)
    {
        var startIndex = 0;
        var endIndex = nums.Length - 1;
        while (startIndex <= endIndex)
        {
            var middleIndex = startIndex + (endIndex - startIndex) / 2;
            var leftMost = nums[startIndex];
            var rightMost = nums[endIndex];
            var middlePivot = nums[middleIndex];

            if (leftMost == target || rightMost == target || middlePivot == target)
            {
                return true;
            }

            if (leftMost == rightMost)
            {
                startIndex++;
                endIndex--;
            }
            else
            {
                if (rightMost >= middlePivot)
                {
                    if (target > middlePivot && target < rightMost)
                    {
                        startIndex = middleIndex + 1;
                    }
                    else
                    {
                        endIndex = middleIndex - 1;
                    }
                }
                else
                {
                    if (target < middlePivot && target > rightMost)
                    {
                        endIndex = middleIndex - 1;
                    }
                    else
                    {
                        startIndex = middleIndex + 1;
                    }
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