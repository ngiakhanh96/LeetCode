namespace ConsoleApp1.BinarySearch;

[LastVisited(2022, 12, 20)]
public class _1283
{
    public int SmallestDivisor(int[] nums, int threshold)
    {
        var minDivisor = 1;
        var maxDivisor = nums.Max();

        while (minDivisor < maxDivisor)
        {
            var midDivisor = minDivisor + (maxDivisor - minDivisor) / 2;
            var currentSum = 0;
            foreach (var num in nums)
            {
                currentSum += (int)Math.Ceiling((float)num / midDivisor);
            }

            if (currentSum <= threshold)
            {
                maxDivisor = midDivisor;
            }
            else
            {
                minDivisor = midDivisor + 1;
            }
        }

        return minDivisor;
    }
}