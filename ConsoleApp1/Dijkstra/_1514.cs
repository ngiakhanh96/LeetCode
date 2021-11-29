using ConsoleApp1.Heap;

namespace ConsoleApp1.Dijkstra;

public class _1514
{
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end)
    {
        var adjacentNodes = new List<double[]>[n];
        for (int i = 0; i < adjacentNodes.Length; i++)
        {
            adjacentNodes[i] = new List<double[]>();
        }

        for (int i = 0; i < edges.Length; i++)
        {
            var startNode = edges[i][0];
            var endNode = edges[i][1];
            adjacentNodes[startNode].Add(new double[] { endNode, succProb[i] });
            adjacentNodes[endNode].Add(new double[] { startNode, succProb[i] });
        }

        var d = new double[n];
        d[start] = 1;
        var maxHeap = new MaxHeap<DijkstraNode>();
        maxHeap.Add(new DijkstraNode
        {
            Num = (float)d[start],
            NodeIndex = start
        });

        while (!maxHeap.IsEmpty())
        {
            var currentNode = maxHeap.Pop();
            if (currentNode.NodeIndex == end)
            {
                break;
            }
            foreach (var adjacentNode in adjacentNodes[currentNode.NodeIndex])
            {
                var adjacentNodeIndex = (int)adjacentNode[0];
                var weight = adjacentNode[1];
                if (d[currentNode.NodeIndex] * weight > d[adjacentNodeIndex])
                {
                    d[adjacentNodeIndex] = d[currentNode.NodeIndex] * weight;
                    maxHeap.Add(new DijkstraNode
                    {
                        Num = (float)d[adjacentNodeIndex],
                        NodeIndex = adjacentNodeIndex
                    });
                }
            }
        }

        return d[end];
    }

    public double MaxProbability2(int n, int[][] edges, double[] succProb, int start, int end)
    {
        var adjacentNodes = new List<double[]>[n];
        for (int i = 0; i < adjacentNodes.Length; i++)
        {
            adjacentNodes[i] = new List<double[]>();
        }

        for (int i = 0; i < edges.Length; i++)
        {
            var startNode = edges[i][0];
            var endNode = edges[i][1];
            adjacentNodes[startNode].Add(new double[] { endNode, succProb[i] });
            adjacentNodes[endNode].Add(new double[] { startNode, succProb[i] });
        }

        var d = new double[n];
        d[start] = 1;
        var maxHeap = new PriorityQueue<DijkstraNode, float>(new MaxHeapFloatComparer());
        maxHeap.Enqueue(
            new DijkstraNode
            {
                Num = (float)d[start],
                NodeIndex = start
            },
            (float)d[start]);

        while (maxHeap.Count > 0)
        {
            var currentNode = maxHeap.Dequeue();
            if (currentNode.NodeIndex == end)
            {
                break;
            }
            foreach (var adjacentNode in adjacentNodes[currentNode.NodeIndex])
            {
                var adjacentNodeIndex = (int)adjacentNode[0];
                var weight = adjacentNode[1];
                if (d[currentNode.NodeIndex] * weight > d[adjacentNodeIndex])
                {
                    d[adjacentNodeIndex] = d[currentNode.NodeIndex] * weight;
                    maxHeap.Enqueue(
                        new DijkstraNode
                        {
                            Num = (float)d[adjacentNodeIndex],
                            NodeIndex = adjacentNodeIndex
                        },
                        (float)d[adjacentNodeIndex]);
                }
            }
        }

        return d[end];
    }
}