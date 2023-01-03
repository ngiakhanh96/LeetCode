namespace ConsoleApp1.TwoPointers.Opposite;

[LastVisited(2023, 01, 03)]
public class _15
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        System.Array.Sort(nums);
        var result = new List<IList<int>>();
        for (var i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }
            var firstPointer = i + 1;
            var secondPointer = nums.Length - 1;
            var target = -nums[i];
            while (firstPointer < secondPointer)
            {
                if (firstPointer > i + 1 && nums[firstPointer] == nums[firstPointer - 1])
                {
                    firstPointer++;
                    continue;
                }
                if (secondPointer < nums.Length - 1 && nums[secondPointer] == nums[secondPointer + 1])
                {
                    secondPointer--;
                    continue;
                }
                if (nums[firstPointer] + nums[secondPointer] == target)
                {
                    result.Add(new List<int> { nums[i], nums[firstPointer], nums[secondPointer] });
                    secondPointer--;
                    firstPointer++;
                }
                else if (nums[firstPointer] + nums[secondPointer] > target)
                {
                    secondPointer--;
                }
                else
                {
                    firstPointer++;
                }
            }
        }
        return result;
    }
}