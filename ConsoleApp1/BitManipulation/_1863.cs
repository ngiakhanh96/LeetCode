namespace ConsoleApp1.BitManipulation;

public class _1863
{
    // Fucking hard to understand solution at https://leetcode.com/problems/sum-of-all-subset-xor-totals/discuss/1211177/Simple-trick-oror-4-lines-of-code-oror-Explained!!
    // Each subset with XOR result containing ith bit set
    // contains 2 part (part containing elements with ith bit set) and (part containing elements without ith bit set)
    // Therefore total subsets with XOR results containing ith bit set is calculated by number of ways of choosing first part * number of ways of choosing second part
    public int SubsetXORSum(int[] nums)
    {
        var res = 0;
        foreach (var num in nums)
        {
            res |= num;
        }
        return res * (1 << (nums.Length - 1));
    }

    public int SubsetXORSum2(int[] nums)
    {
        var sum = 0;
        for (var i = 0; i < Math.Pow(2, nums.Length); i++)
        {
            sum += GetUnmaskIndex(i, nums.Length).Aggregate(0, (currentXor, nextIndex) => nums[nextIndex] ^ currentXor);
        }

        return sum;
    }

    private IList<int> GetUnmaskIndex(int n, int length)
    {
        var complement = 1;
        var resultList = new List<int>();
        while (n != 0)
        {
            if (GetBit(n, 0) == 1)
            {
                resultList = resultList.Prepend(length - complement).ToList();
            }

            n >>= 1;
            complement++;
        }

        return resultList;
    }

    private int GetBit(int n, int position)
    {
        return (n >> position) & 1;
    }
}