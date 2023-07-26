namespace ConsoleApp1.Matrix;

[LastVisited(2023, 07, 27)]
public class _73
{
    public void SetZeroes(int[][] matrix)
    {
        var shouldSetFirstRowToZero = false;
        var shouldSetFirstColToZero = false;
        for (var row = 0; row < matrix.Length; row++)
        {
            for (var col = 0; col < matrix[0].Length; col++)
            {
                if (matrix[row][col] == 0)
                {
                    if (row == 0)
                    {
                        shouldSetFirstRowToZero = true;
                    }
                    else
                    {
                        matrix[row][0] = 0;
                    }

                    if (col == 0)
                    {
                        shouldSetFirstColToZero = true;
                    }
                    else
                    {
                        matrix[0][col] = 0;
                    }
                }
            }
        }
        for (var col = 1; col < matrix[0].Length; col++)
        {
            if (matrix[0][col] == 0)
            {
                for (var row = 0; row < matrix.Length; row++)
                {
                    matrix[row][col] = 0;
                }
            }
        }
        for (var row = 1; row < matrix.Length; row++)
        {
            if (matrix[row][0] == 0)
            {
                for (var col = 0; col < matrix[0].Length; col++)
                {
                    matrix[row][col] = 0;
                }
            }
        }

        if (shouldSetFirstColToZero)
        {
            for (var row = 0; row < matrix.Length; row++)
            {
                matrix[row][0] = 0;
            }
        }

        if (shouldSetFirstRowToZero)
        {
            for (var col = 0; col < matrix[0].Length; col++)
            {
                matrix[0][col] = 0;
            }
        }
    }
}