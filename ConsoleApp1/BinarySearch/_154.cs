namespace ConsoleApp1.BinarySearch;

public class _154
{
    public int FindMin(int[] nums)
    {
        var lowIndex = 0;
        var highIndex = nums.Length - 1;
        var minValue = int.MaxValue;
        while (lowIndex < highIndex)
        {
            var middleIndex = lowIndex + (highIndex - lowIndex) / 2;
            var middleValue = nums[middleIndex];
            var lowValue = nums[lowIndex];
            var highValue = nums[highIndex];
            if (lowValue == highValue)
            {
                lowIndex++;
                highIndex--;
                minValue = Math.Min(lowValue, minValue);
            }
            else
            {
                if (highValue >= middleValue)
                {
                    highIndex = middleIndex;
                }
                else
                {
                    lowIndex = middleIndex + 1;
                }
            }
        }

        return Math.Min(nums[lowIndex], minValue);
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