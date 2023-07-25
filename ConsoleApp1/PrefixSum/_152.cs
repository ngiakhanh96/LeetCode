namespace ConsoleApp1.PrefixSum;

[LastVisited(2023, 07, 25)]
public class _152
{
    public int MaxProduct(int[] nums)
    {
        var largestProduct = int.MinValue;
        var currentMaxProduct = 1;
        var currentMinProduct = 1;
        foreach (var num in nums)
        {
            var oldCurrentMaxProduct = currentMaxProduct;
            currentMaxProduct = Math.Max(currentMaxProduct * num, Math.Max(num, currentMinProduct * num));
            currentMinProduct = Math.Min(currentMinProduct * num, Math.Min(num, oldCurrentMaxProduct * num));
            largestProduct = Math.Max(largestProduct, currentMaxProduct);
        }
        return largestProduct;
    }
}