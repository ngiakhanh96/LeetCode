namespace ConsoleApp1.TwoPointers.Opposite;

[LastVisited(2023, 01, 03)]
public class _240
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var row = matrix.Length - 1;
        var col = 0;
        while (row >= 0 && col < matrix[0].Length)
        {
            if (matrix[row][col] == target)
            {
                return true;
            }

            if (matrix[row][col] < target)
            {
                col++;
            }
            else
            {
                row--;
            }
        }

        return false;
    }
}