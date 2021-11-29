namespace ConsoleApp1.BinaryTree.DFS;

public class _323
{
    public List<int>[] AdjacentList { get; set; }

    public bool[] VisitedNodes { get; set; }
    public int CountComponents(int n, int[][] edges)
    {
        AdjacentList = new List<int>[n];
        VisitedNodes = new bool[n];
        foreach (var edge in edges)
        {
            if (AdjacentList[edge[0]] == null)
            {
                AdjacentList[edge[0]] = new List<int> { edge[1] };
            }
            else
            {
                AdjacentList[edge[0]].Add(edge[1]);
            }

            if (AdjacentList[edge[1]] == null)
            {
                AdjacentList[edge[1]] = new List<int> { edge[0] };
            }
            else
            {
                AdjacentList[edge[1]].Add(edge[0]);
            }
        }

        var count = 0;
        for (var i = 0; i < AdjacentList.Length; i++)
        {
            if (!VisitedNodes[i])
            {
                count++;
                Dfs(i);
            }
        }

        return count;
    }

    private void Dfs(int index)
    {
        VisitedNodes[index] = true;
        if (AdjacentList[index] == null)
        {
            return;
        }
        foreach (var neighbor in AdjacentList[index])
        {
            if (!VisitedNodes[neighbor])
            {
                Dfs(neighbor);
            }
        }
    }
}