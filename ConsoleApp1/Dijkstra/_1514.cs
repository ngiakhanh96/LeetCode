namespace ConsoleApp1.Dijkstra;

public class _1514
{
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end)
    {
        var adjacentNodes = new List<double[]>[n];
        for (var i = 0; i < adjacentNodes.Length; i++)
        {
            adjacentNodes[i] = new List<double[]>();
        }

        for (var i = 0; i < edges.Length; i++)
        {
            var startNode = edges[i][0];
            var endNode = edges[i][1];
            adjacentNodes[startNode].Add(new[] { endNode, succProb[i] });
            adjacentNodes[endNode].Add(new[] { startNode, succProb[i] });
        }

        var d = new double[n];
        d[start] = 1;
        var maxHeap = new MaxPriorityQueue<int, double>();
        maxHeap.Enqueue(start, d[start]);

        while (maxHeap.Count > 0)
        {
            var currentNode = maxHeap.Dequeue();
            if (currentNode == end)
            {
                break;
            }
            foreach (var adjacentNode in adjacentNodes[currentNode])
            {
                var adjacentNodeIndex = (int)adjacentNode[0];
                var weight = adjacentNode[1];
                if (d[currentNode] * weight > d[adjacentNodeIndex])
                {
                    d[adjacentNodeIndex] = d[currentNode] * weight;
                    maxHeap.Enqueue(adjacentNodeIndex, d[adjacentNodeIndex]);
                }
            }
        }

        return d[end];
    }

    public double MaxProbability2(int n, int[][] edges, double[] succProb, int start, int end)
    {
        var adjacentNodes = new List<double[]>[n];
        for (var i = 0; i < adjacentNodes.Length; i++)
        {
            adjacentNodes[i] = new List<double[]>();
        }

        for (var i = 0; i < edges.Length; i++)
        {
            var startNode = edges[i][0];
            var endNode = edges[i][1];
            adjacentNodes[startNode].Add(new[] { endNode, succProb[i] });
            adjacentNodes[endNode].Add(new[] { startNode, succProb[i] });
        }

        var d = new double[n];
        d[start] = 1;
        var maxHeap = new MaxPriorityQueue<int, double>();
        maxHeap.Enqueue(start, d[start]);

        while (maxHeap.Count > 0)
        {
            var currentNode = maxHeap.Dequeue();
            if (currentNode == end)
            {
                break;
            }
            foreach (var adjacentNode in adjacentNodes[currentNode])
            {
                var adjacentNodeIndex = (int)adjacentNode[0];
                var weight = adjacentNode[1];
                if (d[currentNode] * weight > d[adjacentNodeIndex])
                {
                    d[adjacentNodeIndex] = d[currentNode] * weight;
                    maxHeap.Enqueue(adjacentNodeIndex, d[adjacentNodeIndex]);
                }
            }
        }

        return d[end];
    }
}