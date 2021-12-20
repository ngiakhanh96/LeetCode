namespace ConsoleApp1.DP.LIS
{
    public class _63
    {
        // Bottom-up
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            if (obstacleGrid[0][0] == 1 || obstacleGrid[obstacleGrid.Length - 1][obstacleGrid[0].Length - 1] == 1)
            {
                return 0;
            }
            var result = new int[obstacleGrid.Length, obstacleGrid[0].Length];

            result[0, 0] = 1;

            for (int i = 0; i < obstacleGrid.Length; i++)
            {
                for (int j = 0; j < obstacleGrid[0].Length; j++)
                {
                    if (i > 0 || j > 0)
                    {
                        var leftMinValue = j - 1 >= 0 && obstacleGrid[i][j - 1] == 0 ? result[i, j - 1] : 0;
                        var upMinValue = i - 1 >= 0 && obstacleGrid[i - 1][j] == 0 ? result[i - 1, j] : 0;
                        result[i, j] = leftMinValue + upMinValue;
                    }
                }
            }

            return result[obstacleGrid.Length - 1, obstacleGrid[0].Length - 1];
        }
    }
}
