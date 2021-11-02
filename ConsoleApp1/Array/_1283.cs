namespace ConsoleApp1.Array;

public class _1283
{
    public int SmallestDivisor(int[] nums, int threshold)
    {
        var minDivisor = 1;
        var maxDivisor = nums.Max();
        var smallestDivisor = int.MaxValue;

        while (minDivisor <= maxDivisor)
        {
            var midDivisor = minDivisor + (maxDivisor - minDivisor) / 2;
            var currentSum = 0;
            foreach (var num in nums)
            {
                currentSum += (int)Math.Ceiling((float)num / midDivisor);
            }

            if (currentSum <= threshold)
            {
                smallestDivisor = midDivisor;
                maxDivisor = midDivisor - 1;
            }
            else
            {
                minDivisor = midDivisor + 1;
            }
        }

        return smallestDivisor;
    }
}