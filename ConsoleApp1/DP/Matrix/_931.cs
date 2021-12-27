namespace ConsoleApp1.DP.Matrix;

public class _931
{
    // Bottom-up
    public int MinFallingPathSum(int[][] matrix)
    {
        var result = new int[matrix.Length, matrix[0].Length];

        for (int i = 0; i < matrix.Length; i++)
        {

            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (i == 0)
                {
                    result[i, j] = matrix[i][j];
                }
                else
                {
                    var upLeftMinValue = i - 1 >= 0 && j - 1 >= 0 ? result[i - 1, j - 1] : int.MaxValue;
                    var upMiddleMinValue = i - 1 >= 0 ? result[i - 1, j] : int.MaxValue;
                    var upRightMinValue = i - 1 >= 0 && j + 1 <= matrix[0].Length - 1 ? result[i - 1, j + 1] : int.MaxValue;
                    result[i, j] = new int[] { upLeftMinValue, upMiddleMinValue, upRightMinValue }.Min() + matrix[i][j];
                }
            }
        }

        var res = int.MaxValue;
        for (int j = 0; j < matrix[0].Length; j++)
        {
            res = Math.Min(result[matrix.Length - 1, j], res);
        }
        return res;
    }
}