namespace ConsoleApp1._2dArray;

public class _547
{
    public bool[] IsVisited { get; set; }

    public int[][] IsConnected { get; set; }

    public Queue<int> BfsQueue { get; set; } = new Queue<int>();

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


    public int FindCircleNum2(int[][] isConnected)
    {
        IsConnected = isConnected;
        IsVisited = new bool[isConnected.Length];
        var numOfProvinces = 0;
        for (int i = 0; i < IsVisited.Length; i++)
        {
            if (!IsVisited[i])
            {
                numOfProvinces++;
                Bfs(i);
            }
        }
        return numOfProvinces;
    }

    private void Bfs(int index)
    {
        BfsQueue.Enqueue(index);
        IsVisited[index] = true;
        Bfs();
    }

    private void Bfs()
    {
        if (BfsQueue.Count == 0)
        {
            return;
        }
        var index = BfsQueue.Dequeue();
        for (var i = 0; i < IsConnected[index].Length; i++)
        {
            if (i != index && IsConnected[index][i] == 1 && !IsVisited[i])
            {
                BfsQueue.Enqueue(i);
                IsVisited[i] = true;
            }
        }

        Bfs();
    }
}