namespace ConsoleApp1.Array;

public class _81
{
    public bool Search(int[] nums, int target)
    {
        var startIndex = 0;
        var endIndex = nums.Length - 1;
        while (startIndex <= endIndex)
        {
            var middleIndex = (startIndex + endIndex) / 2;
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
}