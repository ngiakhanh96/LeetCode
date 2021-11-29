namespace ConsoleApp1.HashTable;

public class _974
{
    public int SubarraysDivByK(int[] nums, int k)
    {
        var sum = 0;
        var sumDict = new Dictionary<int, int> { { 0, 1 } };
        var res = 0;
        foreach (var num in nums)
        {
            sum += num;

            var remainder = sum % k;
            if (sumDict.ContainsKey(remainder))
            {
                res += sumDict[remainder];
            }

            var remainder2 = Math.Abs(-k + sum % k) < k ? -k + sum % k : k + sum % k;
            if (sumDict.ContainsKey(remainder2))
            {
                res += sumDict[remainder2];
            }

            if (!sumDict.TryAdd(remainder, 1))
            {
                sumDict[remainder]++;
            }
        }
        return res;
    }
}