namespace ConsoleApp1._1_1FirstOccurrence;

// See https://leetcode.com/problems/contiguous-array/discuss/99655/Python-O(n)-Solution-with-Visual-Explanation
public class _525
{
    public int FindMaxLength(int[] nums)
    {
        var count = 0;
        var dict = new Dictionary<int, int> { { 0, -1 } };
        var maxLength = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            count += nums[i] == 0 ? -1 : 1;
            if (dict.ContainsKey(count))
            {
                maxLength = Math.Max(maxLength, i - dict[count]);
            }
            dict.TryAdd(count, i);

        }
        return maxLength;
    }
}