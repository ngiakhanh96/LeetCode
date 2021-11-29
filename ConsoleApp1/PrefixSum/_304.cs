namespace ConsoleApp1.PrefixSum;

public class _304
{
    public class NumMatrix
    {
        private readonly int[][] _matrix;
        public NumMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    matrix[i][j] +=
                        (i > 0 ? matrix[i - 1][j] : 0) +
                        (j > 0 ? matrix[i][j - 1] : 0) -
                        (i > 0 && j > 0 ? matrix[i - 1][j - 1] : 0);
                }
            }
            _matrix = matrix;
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            return _matrix[row2][col2]
                   - (col1 > 0 ? _matrix[row2][col1 - 1] : 0)
                   - (row1 > 0 ? _matrix[row1 - 1][col2] : 0)
                   + (col1 > 0 && row1 > 0 ? _matrix[row1 - 1][col1 - 1] : 0);
        }
    }

}