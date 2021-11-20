﻿namespace ConsoleApp1._2dArray;

public class _743
{
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        var adjacentNodes = new List<int[]>[n];
        for (int i = 0; i < adjacentNodes.Length; i++)
        {
            adjacentNodes[i] = new List<int[]>();
        }
        foreach (var time in times)
        {
            var nodeIndex = time[0] - 1;
            adjacentNodes[nodeIndex].Add(new[] { time[1] - 1, time[2] });
        }

        var d = Enumerable.Repeat(int.MaxValue, n).ToArray();
        k--;
        d[k] = 0;
        var minHeap = new MinHeap<DijkstraNode>();
        minHeap.Add(new DijkstraNode
        {
            Num = d[k],
            NodeIndex = k
        });

        while (!minHeap.IsEmpty())
        {
            var currentNode = minHeap.Pop();
            foreach (var adjacentNode in adjacentNodes[currentNode.NodeIndex])
            {
                var targetNodeIndex = adjacentNode[0];
                var weight = adjacentNode[1];
                if (d[currentNode.NodeIndex] + weight < d[targetNodeIndex])
                {
                    d[targetNodeIndex] = d[currentNode.NodeIndex] + weight;
                    minHeap.Add(new DijkstraNode
                    {
                        Num = d[targetNodeIndex],
                        NodeIndex = targetNodeIndex
                    });
                }
            }
        }

        var maxDistance = d.Max();
        return maxDistance < int.MaxValue ? maxDistance : -1;
    }
}