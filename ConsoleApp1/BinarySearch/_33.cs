namespace ConsoleApp1.BinarySearch;

public class _33
{
    public int Search(int[] nums, int target)
    {
        var leftMostIndex = 0;
        var rightMostIndex = nums.Length - 1;

        while (leftMostIndex <= rightMostIndex)
        {
            var middlePivotIndex = leftMostIndex + (rightMostIndex - leftMostIndex) / 2;
            var rightMost = nums[rightMostIndex];
            var leftMost = nums[leftMostIndex];
            var middlePivot = nums[middlePivotIndex];
            if (rightMost == target)
            {
                return rightMostIndex;
            }

            if (leftMost == target)
            {
                return leftMostIndex;
            }

            if (middlePivot == target)
            {
                return middlePivotIndex;
            }

            if (rightMost > middlePivot)
            {
                if (target > middlePivot && target < rightMost)
                {
                    leftMostIndex = middlePivotIndex + 1;
                }
                else
                {
                    rightMostIndex = middlePivotIndex - 1;
                }
            }
            else
            {
                if (target > rightMost && target < middlePivot)
                {
                    rightMostIndex = middlePivotIndex - 1;
                }
                else
                {
                    leftMostIndex = middlePivotIndex + 1;
                }
            }
        }

        return -1;
    }
}