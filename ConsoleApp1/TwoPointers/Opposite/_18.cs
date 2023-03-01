namespace ConsoleApp1.TwoPointers.Opposite;

[LastVisited(2023, 01, 03)]
public class _18
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        System.Array.Sort(nums);
        return KSum(nums, target, 4, 0);
    }

    private IList<IList<int>> KSum(int[] nums, long target, int k, int start)
    {
        if (k == 2)
        {
            return TwoSum(nums, target, start);
        }
        var result = new List<IList<int>>();
        for (var i = start; i < nums.Length - (k - 1); i++)
        {
            if (i > start && nums[i] == nums[i - 1])
            {
                continue;
            }
            var lists = KSum(nums, target - nums[i], k - 1, i + 1);
            foreach (var list in lists)
            {
                list.Add(nums[i]);
                result.Add(list);
            }
        }
        return result;
    }

    private List<IList<int>> TwoSum(int[] nums, long target, int start)
    {
        var result = new List<IList<int>>();
        var pointer1 = start;
        var pointer2 = nums.Length - 1;
        while (pointer1 < pointer2)
        {
            if (pointer1 > start && nums[pointer1] == nums[pointer1 - 1])
            {
                pointer1++;
                continue;
            }
            if (pointer2 < nums.Length - 1 && nums[pointer2] == nums[pointer2 + 1])
            {
                pointer2--;
                continue;
            }
            if (nums[pointer1] + nums[pointer2] == target)
            {
                result.Add(new List<int> { nums[pointer1], nums[pointer2] });
                pointer1++;
                pointer2--;
            }
            else if (nums[pointer1] + nums[pointer2] < target)
            {
                pointer1++;
            }
            else
            {
                pointer2--;
            }
        }
        return result;
    }

    public IList<IList<int>> FourSum2(int[] nums, int target)
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