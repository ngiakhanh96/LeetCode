namespace ConsoleApp1.Dijkstra;

public class _787
{
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        var adjacentNodes = new List<int[]>[n];
        for (var i = 0; i < adjacentNodes.Length; i++)
        {
            adjacentNodes[i] = new List<int[]>();
        }

        foreach (var flight in flights)
        {
            var startNode = flight[0];
            var endNode = flight[1];
            var weight = flight[2];
            adjacentNodes[startNode].Add(new[] { endNode, weight });
        }

        var d = new int[n, k + 1];
        for (var i = 0; i < d.GetLength(0); i++)
        {
            for (var j = 0; j < d.GetLength(1); j++)
            {
                d[i, j] = int.MaxValue;
            }
        }
        d[src, k] = 0;
        var minHeap = new PriorityQueue<DijkstraNodeWithK, int>();
        minHeap.Enqueue(
            new DijkstraNodeWithK
            {
                Priority = d[src, k],
                NodeIndex = src,
                RemainingStops = k
            },
            d[src, k]);
        var minFlightPrice = int.MaxValue;
        while (minHeap.Count > 0)
        {
            var currentNode = minHeap.Dequeue();
            if (currentNode.NodeIndex == dst)
            {
                minFlightPrice = currentNode.Priority;
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
                    minHeap.Enqueue(
                        new DijkstraNodeWithK
                        {
                            Priority = d[targetNodeIndex, newRemainingStops],
                            NodeIndex = targetNodeIndex,
                            RemainingStops = newRemainingStops
                        },
                        d[targetNodeIndex, newRemainingStops]);
                }
            }
        }

        return minFlightPrice == int.MaxValue ? -1 : minFlightPrice;
    }

    public int FindCheapestPrice2(int n, int[][] flights, int src, int dst, int k)
    {
        var adjacentNodes = new List<int[]>[n];
        for (var i = 0; i < adjacentNodes.Length; i++)
        {
            adjacentNodes[i] = new List<int[]>();
        }

        foreach (var flight in flights)
        {
            var startNode = flight[0];
            var endNode = flight[1];
            var weight = flight[2];
            adjacentNodes[startNode].Add(new[] { endNode, weight });
        }

        var d = new int[n, k + 1];
        for (var i = 0; i < d.GetLength(0); i++)
        {
            for (var j = 0; j < d.GetLength(1); j++)
            {
                d[i, j] = int.MaxValue;
            }
        }
        d[src, k] = 0;
        var minHeap = new PriorityQueue<DijkstraNodeWithK, int>();
        minHeap.Enqueue(
            new DijkstraNodeWithK
            {
                Priority = d[src, k],
                NodeIndex = src,
                RemainingStops = k
            },
            d[src, k]);
        var minFlightPrice = int.MaxValue;
        while (minHeap.Count > 0)
        {
            var currentNode = minHeap.Dequeue();
            if (currentNode.NodeIndex == dst)
            {
                minFlightPrice = currentNode.Priority;
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
                    minHeap.Enqueue(
                        new DijkstraNodeWithK
                        {
                            Priority = d[targetNodeIndex, newRemainingStops],
                            NodeIndex = targetNodeIndex,
                            RemainingStops = newRemainingStops
                        },
                        d[targetNodeIndex, newRemainingStops]);
                }
            }
        }

        return minFlightPrice == int.MaxValue ? -1 : minFlightPrice;
    }

    public class DijkstraNodeWithK : DijkstraNode
    {
        public int RemainingStops { get; init; }
    }
}