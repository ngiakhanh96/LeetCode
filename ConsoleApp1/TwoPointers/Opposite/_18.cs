namespace ConsoleApp1.TwoPointers.Opposite;

public class _18
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        var res = new List<IList<int>>();
        if (nums.Length < 4)
        {
            return res;
        }
        System.Array.Sort(nums);
        for (int i = 0; i < nums.Length - 3; i++)
        {
            if (i > 0 && nums[i - 1] == nums[i])
            {
                continue;
            }

            for (int l = i + 1; l < nums.Length - 2; l++)
            {
                if (l > i + 1 && nums[l - 1] == nums[l])
                {
                    continue;
                }
                var newTarget = target - nums[i] - nums[l];
                var j = l + 1;
                var k = nums.Length - 1;
                while (j < k)
                {
                    if (j > l + 1 && nums[j - 1] == nums[j])
                    {
                        j++;
                        continue;
                    }

                    if (k < nums.Length - 1 && nums[k] == nums[k + 1])
                    {
                        k--;
                        continue;
                    }

                    if (nums[j] + nums[k] == newTarget)
                    {
                        res.Add(new List<int> { nums[i], nums[l], nums[j], nums[k] });
                        j++;
                        k--;
                    }
                    else if (nums[j] + nums[k] < newTarget)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }
            }
        }
        return res;
    }
}