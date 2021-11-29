namespace ConsoleApp1.TwoPointers.Opposite;

public class _15
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var res = new List<IList<int>>();
        if (nums.Length < 3)
        {
            return res;
        }
        System.Array.Sort(nums);
        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i - 1] == nums[i])
            {
                continue;
            }
            var target = -nums[i];
            var j = i + 1;
            var k = nums.Length - 1;
            while (j < k)
            {
                if (j > i + 1 && nums[j - 1] == nums[j])
                {
                    j++;
                    continue;
                }

                if (k < nums.Length - 1 && nums[k] == nums[k + 1])
                {
                    k--;
                    continue;
                }

                if (nums[j] + nums[k] == target)
                {
                    res.Add(new List<int> { nums[i], nums[j], nums[k] });
                    j++;
                    k--;
                }
                else if (nums[j] + nums[k] < target)
                {
                    j++;
                }
                else
                {
                    k--;
                }
            }
        }
        return res;
    }
}