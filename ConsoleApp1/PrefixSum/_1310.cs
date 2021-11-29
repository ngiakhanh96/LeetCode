namespace ConsoleApp1.PrefixSum;

public class _1310
{
    public int[] XorQueries(int[] arr, int[][] queries)
    {
        var res = new int[queries.Length];
        var prefixXor = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            prefixXor[i] = (i > 0 ? prefixXor[i - 1] : 0) ^ arr[i];
        }

        for (int i = 0; i < queries.Length; i++)
        {
            res[i] = prefixXor[queries[i][1]] ^ (
                queries[i][0] > 0
                    ? prefixXor[queries[i][0] - 1]
                    : 0);
        }

        return res;
    }
}