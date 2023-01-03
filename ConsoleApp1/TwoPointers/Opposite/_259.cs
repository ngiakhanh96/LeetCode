namespace ConsoleApp1.TwoPointers.Opposite;

[LastVisited(2023, 01, 03)]
public class _259
{
    public int ThreeSumSmaller(int[] nums, int target)
    {
        System.Array.Sort(nums);
        var result = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            var pointer1 = i + 1;
            var pointer2 = nums.Length - 1;
            var newTarget = target - nums[i];
            while (pointer1 < pointer2)
            {
                if (nums[pointer1] + nums[pointer2] < newTarget)
                {
                    result += pointer2 - pointer1;
                    pointer1++;
                }
                else
                {
                    pointer2--;
                }
            }
        }

        return result;
    }
}