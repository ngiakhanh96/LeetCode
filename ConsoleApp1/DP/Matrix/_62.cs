namespace ConsoleApp1.DP.Matrix;

public class _62
{
    // Bottom-up
    public int UniquePaths(int m, int n)
    {
        var result = new int[m, n];
        result[0, 0] = 1;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i > 0 || j > 0)
                {
                    var leftMinValue = j - 1 >= 0 ? result[i, j - 1] : 0;
                    var upMinValue = i - 1 >= 0 ? result[i - 1, j] : 0;
                    result[i, j] = leftMinValue + upMinValue;
                }
            }
        }

        return result[m - 1, n - 1];
    }
}