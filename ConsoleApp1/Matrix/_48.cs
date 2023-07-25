namespace ConsoleApp1.Matrix;

[LastVisited(2023, 07, 25)]
public class _48
{
    public void Rotate(int[][] matrix)
    {
        var numLayers = (Math.Min(matrix.Length, matrix[0].Length) + 1) / 2;
        for (var layer = 0; layer < numLayers; layer++)
        {
            var currentRow = layer;
            for (var col = layer; col < matrix[0].Length - 1 - layer; col++)
            {
                var currentCol = col;
                var temp = matrix[currentRow][currentCol];
                for (var y = 0; y < 4; y++)
                {
                    var newCol = matrix.Length - 1 - currentRow;
                    var newRow = currentCol;
                    (matrix[newRow][newCol], temp) = (temp, matrix[newRow][newCol]);
                    currentCol = newCol;
                    currentRow = newRow;
                }
            }
        }
    }
}