namespace ConsoleApp1.DP.MaxSumDiv;

// Super hard DP. See https://leetcode.com/problems/greatest-sum-divisible-by-three/discuss/559999/Come-here-if-you-can't-seem-to-get-it-(Full-Explanation-%2B-uncondensed-code)
public class _1262
{
    public int MaxSumDivThree(int[] nums)
    {
        var maxSumDivisibleByKWithRemainderAsIndex = new int[3];

        for (int i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            var prevMaxSumDivisibleByKWithRemainderAsIndex = (int[])maxSumDivisibleByKWithRemainderAsIndex.Clone();
            if (num % 3 == 0)
            {
                maxSumDivisibleByKWithRemainderAsIndex[0] = Math.Max(
                    prevMaxSumDivisibleByKWithRemainderAsIndex[0],
                    prevMaxSumDivisibleByKWithRemainderAsIndex[0] > 0 ? num + prevMaxSumDivisibleByKWithRemainderAsIndex[0] : num);
                maxSumDivisibleByKWithRemainderAsIndex[1] = Math.Max(
                    prevMaxSumDivisibleByKWithRemainderAsIndex[1],
                    prevMaxSumDivisibleByKWithRemainderAsIndex[1] > 0 ? num + prevMaxSumDivisibleByKWithRemainderAsIndex[1] : 0);
                maxSumDivisibleByKWithRemainderAsIndex[2] = Math.Max(
                    prevMaxSumDivisibleByKWithRemainderAsIndex[2],
                    prevMaxSumDivisibleByKWithRemainderAsIndex[2] > 0 ? num + prevMaxSumDivisibleByKWithRemainderAsIndex[2] : 0);
            }
            else if (num % 3 == 1)
            {
                maxSumDivisibleByKWithRemainderAsIndex[0] = Math.Max(
                    prevMaxSumDivisibleByKWithRemainderAsIndex[0],
                    prevMaxSumDivisibleByKWithRemainderAsIndex[2] > 0 ? num + prevMaxSumDivisibleByKWithRemainderAsIndex[2] : 0);
                maxSumDivisibleByKWithRemainderAsIndex[1] = Math.Max(
                    prevMaxSumDivisibleByKWithRemainderAsIndex[1],
                    prevMaxSumDivisibleByKWithRemainderAsIndex[0] > 0 ? num + prevMaxSumDivisibleByKWithRemainderAsIndex[0] : num);
                maxSumDivisibleByKWithRemainderAsIndex[2] = Math.Max(
                    prevMaxSumDivisibleByKWithRemainderAsIndex[2],
                    prevMaxSumDivisibleByKWithRemainderAsIndex[1] > 0 ? num + prevMaxSumDivisibleByKWithRemainderAsIndex[1] : 0);
            }
            else if (num % 3 == 2)
            {
                maxSumDivisibleByKWithRemainderAsIndex[0] = Math.Max(
                    prevMaxSumDivisibleByKWithRemainderAsIndex[0],
                    prevMaxSumDivisibleByKWithRemainderAsIndex[1] > 0 ? num + prevMaxSumDivisibleByKWithRemainderAsIndex[1] : 0);
                maxSumDivisibleByKWithRemainderAsIndex[1] = Math.Max(
                    prevMaxSumDivisibleByKWithRemainderAsIndex[1],
                    prevMaxSumDivisibleByKWithRemainderAsIndex[2] > 0 ? num + prevMaxSumDivisibleByKWithRemainderAsIndex[2] : 0);
                maxSumDivisibleByKWithRemainderAsIndex[2] = Math.Max(
                    prevMaxSumDivisibleByKWithRemainderAsIndex[2],
                    prevMaxSumDivisibleByKWithRemainderAsIndex[0] > 0 ? num + prevMaxSumDivisibleByKWithRemainderAsIndex[0] : num);
            }
        }

        return maxSumDivisibleByKWithRemainderAsIndex[0];
    }
}