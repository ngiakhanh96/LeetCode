namespace ConsoleApp1.MinimumSpanningTree;

public class _1584
{
    public int MinCostConnectPoints(int[][] points)
    {
        var minHeap = new MinHeap<PointIndicesWithDistance>();
        for (var i = 0; i < points.Length; i++)
        {
            for (var j = i + 1; j < points.Length; j++)
            {
                var currentPoint = points[i];
                var nextPoint = points[j];
                var distance = Math.Abs(currentPoint[0] - nextPoint[0]) + Math.Abs(currentPoint[1] - nextPoint[1]);
                minHeap.Add(new PointIndicesWithDistance { Num = distance, Point1 = i, Point2 = j });
            }
        }

        var unionFind = new UnionFind<int>(points.Length);
        var cost = 0;
        var count = 0;
        while (count < points.Length - 1 && minHeap.Count > 0)
        {
            var edge = minHeap.Pop();
            if (unionFind.TryUnion(edge.Point1, edge.Point2))
            {
                cost += (int)edge.Num;
                count++;
            }
        }

        return cost;
    }

    public class PointIndicesWithDistance : HeapItem
    {
        public int Point1 { get; set; }

        public int Point2 { get; set; }
    }

    public int MinCostConnectPoints2(int[][] points)
    {
        var edges = new List<(int[], int)>();

        for (var i = 0; i < points.Length; i++)
        {
            for (var j = i + 1; j < points.Length; j++)
            {
                var currentPoint = points[i];
                var nextPoint = points[j];
                var distance = Math.Abs(currentPoint[0] - nextPoint[0]) + Math.Abs(currentPoint[1] - nextPoint[1]);
                edges.Add((new[] { distance, i, j }, distance));
            }
        }

        var minHeap = new PriorityQueue<int[], int>(edges);
        var unionFind = new UnionFind<int>(points.Length);
        var cost = 0;
        var count = 0;
        while (count < points.Length - 1 && minHeap.Count > 0)
        {
            var edge = minHeap.Dequeue();
            if (unionFind.TryUnion(edge[1], edge[2]))
            {
                cost += edge[0];
                count++;
            }
        }

        return cost;
    }
}