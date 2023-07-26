namespace ConsoleApp1.DFS;

[LastVisited(2023, 07, 27)]
public class _79
{
    public bool Exist(char[][] board, string word)
    {
        var characters = word.ToCharArray();
        var visited = new bool[board.Length, board[0].Length];
        const int pointer = 0;
        for (var row = 0; row < board.Length; row++)
        {
            for (var col = 0; col < board[0].Length; col++)
            {
                if (board[row][col] == characters[0] && !visited[row, col])
                {
                    if (Dfs(row, col, board, characters, visited, pointer))
                    {
                        return true;
                    }
                    visited[row, col] = false;
                }
            }
        }
        return false;
    }

    private static bool Dfs(int row, int col, IReadOnlyList<char[]> board, IReadOnlyList<char> characters, bool[,] visited, int pointer)
    {
        if (pointer + 1 == characters.Count)
        {
            return true;
        }
        visited[row, col] = true;
        var nextRows = new[] {
            new[]{row - 1, col},
            new[]{row + 1, col},
            new[]{row, col - 1},
            new[]{row, col + 1}
        };

        foreach (var nextRow in nextRows)
        {
            var nextRowX = nextRow[0];
            var nextRowY = nextRow[1];
            if (nextRowX >= 0 && nextRowX < board.Count && nextRowY >= 0 && nextRowY < board[0].Length &&
                board[nextRowX][nextRowY] == characters[pointer + 1] &&
                !visited[nextRowX, nextRowY])
            {
                if (Dfs(nextRowX, nextRowY, board, characters, visited, pointer + 1))
                {
                    return true;
                }
                visited[nextRowX, nextRowY] = false;
            }
        }
        return false;
    }
}