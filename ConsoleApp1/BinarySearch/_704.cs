namespace ConsoleApp1.BinarySearch;

[LastVisited(2023, 08, 17)]
public class _704
{
    public int Search(int[] nums, int target)
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
            else if (nums[middle] < target)
            {
                low = middle + 1;
            }
            else
            {
                high = middle - 1;
            }
        }

        return -1;
    }
}