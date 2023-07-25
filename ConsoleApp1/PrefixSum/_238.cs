namespace ConsoleApp1.PrefixSum;

[LastVisited(2023, 07, 25)]
public class _238
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var prefixProductFromLeft = new int[nums.Length];
        var product = 1;
        for (var i = 0; i < nums.Length; i++)
        {
            product *= nums[i];
            prefixProductFromLeft[i] = product;
        }
        var prefixProductFromRight = new int[nums.Length];
        product = 1;
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            product *= nums[i];
            prefixProductFromRight[i] = product;
        }

        for (var i = 0; i < nums.Length; i++)
        {
            nums[i] = (i - 1 >= 0 ? prefixProductFromLeft[i - 1] : 1) * (i + 1 < nums.Length ? prefixProductFromRight[i + 1] : 1);
        }
        return nums;
    }
}