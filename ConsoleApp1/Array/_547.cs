namespace ConsoleApp1.Array;

public class _547
{
    public bool[] IsVisited { get; set; }

    public int[][] IsConnected { get; set; }

    public int FindCircleNum(int[][] isConnected)
    {
        IsConnected = isConnected;
        IsVisited = new bool[isConnected.Length];
        var numOfProvinces = 0;
        for (int i = 0; i < IsVisited.Length; i++)
        {
            if (!IsVisited[i])
            {
                numOfProvinces++;
                Dfs(i);
            }
        }
        return numOfProvinces;
    }

    private void Dfs(int index)
    {
        IsVisited[index] = true;
        for (int i = 0; i < IsConnected[index].Length; i++)
        {
            if (i != index && IsConnected[index][i] == 1 && !IsVisited[i])
            {
                Dfs(i);
            }
        }
    }
}