namespace ConsoleApp1.BitManipulation;

public class _421
{
    //Another fucking tricky xor problem. Solution found on https://leetcode.com/problems/maximum-xor-of-two-numbers-in-an-array/solution/
    public int FindMaximumXOR(int[] nums)
    {
        var max_xor = 0;
        var max = nums.Max();
        var index = 0;
        var prefixes = new HashSet<int>();
        while (max >= 1)
        {
            max >>= 1;
            index++;
        }

        for (var i = index; i >= 0; i--)
        {
            max_xor <<= 1;
            var curr_xor = max_xor | 1;
            prefixes.Clear();

            foreach (var num in nums)
            {
                prefixes.Add(num >> i);
            }

            foreach (var prefix in prefixes)
            {
                if (prefixes.Contains(curr_xor ^ prefix))
                {
                    max_xor = curr_xor;
                    break;
                }
            }
        }
        return max_xor;
    }
}