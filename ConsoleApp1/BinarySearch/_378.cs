namespace ConsoleApp1.BinarySearch;

public class _378
{
    public int KthSmallest(int[][] matrix, int k)
    {
        var min = matrix[0][0];
        var max = matrix[matrix.Length - 1][matrix[0].Length - 1];
        while (min < max)
        {
            var mid = min + (max - min) / 2;
            var count = CountLessOrEqual(matrix, mid);
            if (count >= k)
            {
                max = mid;
            }
            else
            {
                min = mid + 1;
            }
        }
        return min;
    }

    private int CountLessOrEqual(int[][] matrix, int mid)
    {
        var col = matrix[0].Length - 1;
        var count = 0;
        for (var row = 0; row < matrix.Length; row++)
        {
            while (matrix[row][col] > mid)
            {
                col--;
                if (col == -1)
                {
                    return count;
                }
            }

            count += col + 1;
        }

        return count;
    }
}