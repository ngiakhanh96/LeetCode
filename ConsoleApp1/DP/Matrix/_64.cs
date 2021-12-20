namespace ConsoleApp1.DP.Matrix
{
    public class _64
    {
        // Bottom-up
        public int MinPathSum(int[][] grid)
        {
            var result = new int[grid.Length, grid[0].Length];
            result[0, 0] = grid[0][0];
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (i > 0 || j > 0)
                    {
                        var leftMinValue = j - 1 >= 0 ? result[i, j - 1] : int.MaxValue;
                        var upMinValue = i - 1 >= 0 ? result[i - 1, j] : int.MaxValue;
                        result[i, j] = Math.Min(leftMinValue, upMinValue) + grid[i][j];
                    }
                }
            }

            return result[grid.Length - 1, grid[0].Length - 1];
        }
    }
}
