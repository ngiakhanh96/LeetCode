﻿namespace ConsoleApp1._2dArray;

public class _787
{
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        var adjacentNodes = new List<int[]>[n];
        for (int i = 0; i < adjacentNodes.Length; i++)
        {
            adjacentNodes[i] = new List<int[]>();
        }

        foreach (var flight in flights)
        {
            var startNode = flight[0];
            var endNode = flight[1];
            var weight = flight[2];
            adjacentNodes[startNode].Add(new int[] { endNode, weight });
        }

        var d = new int[n, k + 1];
        for (int i = 0; i < d.GetLength(0); i++)
        {
            for (int j = 0; j < d.GetLength(1); j++)
            {
                d[i, j] = int.MaxValue;
            }
        }
        d[src, k] = 0;
        var minHeap = new MinHeap<DijkstraNodeWithK>();
        minHeap.Add(new DijkstraNodeWithK
        {
            Num = d[src, k],
            NodeIndex = src,
            RemainingStops = k
        });

        while (!minHeap.IsEmpty())
        {
            var currentNode = minHeap.Pop();
            if (currentNode.NodeIndex == dst)
            {
                break;
            }

            foreach (var adjacentNode in adjacentNodes[currentNode.NodeIndex])
            {
                var targetNodeIndex = adjacentNode[0];
                var weight = adjacentNode[1];
                var newRemainingStops = targetNodeIndex == dst
                    ? currentNode.RemainingStops
                    : currentNode.RemainingStops - 1;

                if (newRemainingStops >= 0 && d[currentNode.NodeIndex, currentNode.RemainingStops] + weight < d[targetNodeIndex, newRemainingStops])
                {
                    d[targetNodeIndex, newRemainingStops] = d[currentNode.NodeIndex, currentNode.RemainingStops] + weight;
                    minHeap.Add(new DijkstraNodeWithK
                    {
                        Num = d[targetNodeIndex, newRemainingStops],
                        NodeIndex = targetNodeIndex,
                        RemainingStops = newRemainingStops
                    });
                }
            }
        }

        var minFlightPrice = int.MaxValue;
        for (int i = 0; i < d.GetLength(1); i++)
        {
            minFlightPrice = minFlightPrice < d[dst, i] ? minFlightPrice : d[dst, i];
        }
        return minFlightPrice == int.MaxValue ? -1 : minFlightPrice;
    }

    public class DijkstraNodeWithK : DijkstraNode
    {
        public int RemainingStops { get; init; }
    }
}