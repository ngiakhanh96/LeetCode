namespace ConsoleApp1._2dArray;

public class _240
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var (x, y) = (0, matrix[0].Length - 1);
        while (x < matrix.Length && y >= 0)
        {
            if (matrix[x][y] == target)
            {
                return true;
            }
            else if (matrix[x][y] < target)
            {
                x++;
            }
            else
            {
                y--;
            }
        }
        return false;
    }
}