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
}