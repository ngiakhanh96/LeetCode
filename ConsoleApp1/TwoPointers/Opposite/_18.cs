namespace ConsoleApp1.TwoPointers.Opposite;

[LastVisited(2023, 01, 03)]
public class _18
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        var result = new List<IList<int>>();
        System.Array.Sort(nums);
        for (var i = 0; i < nums.Length - 3; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }
            for (var j = i + 1; j < nums.Length - 2; j++)
            {
                if (j > i + 1 && nums[j] == nums[j - 1])
                {
                    continue;
                }
                var pointer1 = j + 1;
                var pointer2 = nums.Length - 1;
                var lookFor = (long)target - nums[i] - nums[j];
                while (pointer1 < pointer2)
                {
                    if (pointer1 > j + 1 && nums[pointer1] == nums[pointer1 - 1])
                    {
                        pointer1++;
                        continue;
                    }
                    if (pointer2 < nums.Length - 1 && nums[pointer2] == nums[pointer2 + 1])
                    {
                        pointer2--;
                        continue;
                    }
                    if ((long)nums[pointer1] + nums[pointer2] == lookFor)
                    {
                        result.Add(new List<int> { nums[i], nums[j], nums[pointer1], nums[pointer2] });
                        pointer1++;
                        pointer2--;
                    }
                    else if ((long)nums[pointer1] + nums[pointer2] < lookFor)
                    {
                        pointer1++;
                    }
                    else
                    {
                        pointer2--;
                    }
                }
            }
        }
        return result;
    }
}