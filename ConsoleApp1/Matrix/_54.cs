namespace ConsoleApp1.Matrix;

[LastVisited(2023, 07, 25)]
public class _54
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        var result = new List<int>();
        var numLayers = (Math.Min(matrix.Length, matrix[0].Length) + 1) / 2;
        for (var layer = 0; layer < numLayers; layer++)
        {
            var currentCol = layer;
            var currentRow = layer;
            while (currentCol < matrix[0].Length - layer)
            {
                result.Add(matrix[currentRow][currentCol]);
                currentCol++;
            }
            currentCol--;
            if (matrix.Length == currentRow * 2 + 1)
            {
                break;
            }

            currentRow++;
            while (currentRow < matrix.Length - layer)
            {
                result.Add(matrix[currentRow][currentCol]);
                currentRow++;
            }
            currentRow--;
            if (matrix[0].Length == currentCol * 2 + 1)
            {
                break;
            }

            currentCol--;
            while (currentCol >= layer)
            {
                result.Add(matrix[currentRow][currentCol]);
                currentCol--;
            }
            currentCol++;

            currentRow--;
            while (currentRow > layer)
            {
                result.Add(matrix[currentRow][currentCol]);
                currentRow--;
            }
        }
        return result;
    }
}