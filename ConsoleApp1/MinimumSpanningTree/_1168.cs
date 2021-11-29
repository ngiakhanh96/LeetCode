namespace ConsoleApp1.MinimumSpanningTree;

public class _1168
{
    public int MinCostToSupplyWater(int n, int[] wells, int[][] pipes)
    {
        var pipeList = pipes.ToList();
        for (int i = 0; i < wells.Length; i++)
        {
            pipeList.Add(new int[] { 0, i + 1, wells[i] });
        }

        pipeList.Sort((ele1, ele2) => ele1[2].CompareTo(ele2[2]));
        var unionFind = new UnionFind<int>(pipeList.Count);
        var costs = 0;
        foreach (var pipe in pipeList)
        {
            if (unionFind.TryUnion(pipe[0], pipe[1]))
            {
                costs += pipe[2];
            }

        }

        return costs;
    }
}