namespace ConsoleApp1.TwoPointers.Opposite;

[LastVisited(2023, 01, 02)]
public class _15
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        System.Array.Sort(nums);
        var result = new List<IList<int>>();
        var i = 0;
        while (i < nums.Length - 2)
        {
            if (i > 0 && nums[i] == nums[i - 1])
            {
                i++;
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
            i++;
        }
        return result;
    }
}