namespace ConsoleApp1.TwoPointers.SlidingWindow;

public class _973
{
    private Random Random { get; } = new Random();

    public int[][] KClosest(int[][] points, int k)
    {
        var dict = new Dictionary<int[], int>();
        for (var i = 0; i < points.Length; i++)
        {
            var distanceSquare = points[i][0] * points[i][0] + points[i][1] * points[i][1];
            dict[points[i]] = distanceSquare;
        }
        k--;
        var start = 0;
        var end = points.Length - 1;
        var boundary = -1;
        while (boundary != k)
        {
            if (boundary < k)
            {
                start = boundary + 1;
            }
            else
            {
                end = boundary - 1;
            }

            boundary = LomutoPartition(points, start, end, dict);
        }

        var result = new int[boundary + 1][];
        for (var i = 0; i <= boundary; i++)
        {
            result[i] = points[i];
        }
        return result;
    }

    private int LomutoPartition(int[][] points, int start, int end, Dictionary<int[], int> dict)
    {
        var randomIndex = Random.Next(start, end + 1);
        var temp3 = points[randomIndex];
        points[randomIndex] = points[end];
        points[end] = temp3;

        var boundary = start;
        var pivot = dict[points[end]];
        for (var i = start; i < end; i++)
        {
            if (dict[points[i]] < pivot)
            {
                var temp = points[i];
                points[i] = points[boundary];
                points[boundary++] = temp;
            }
        }

        var temp2 = points[end];
        points[end] = points[boundary];
        points[boundary] = temp2;

        return boundary;
    }

    public int[][] KClosest2(int[][] points, int k)
    {
        var dict = new Dictionary<int, List<int>>();
        var pointDistanceSquares = new int[points.Length];
        for (var i = 0; i < points.Length; i++)
        {
            var distanceSquare = points[i][0] * points[i][0] + points[i][1] * points[i][1];
            if (!dict.TryAdd(distanceSquare, new List<int> { i }))
            {
                dict[distanceSquare].Add(i);
            }

            pointDistanceSquares[i] = distanceSquare;
        }

        var start = 0;
        var end = pointDistanceSquares.Length - 1;
        var boundary = LomutoPartition(pointDistanceSquares, start, end);
        var indexPos = k - 1;
        while (boundary != indexPos)
        {
            if (boundary < indexPos)
            {
                start = boundary + 1;
            }
            else
            {
                end = boundary - 1;
            }

            boundary = LomutoPartition(pointDistanceSquares, start, end);
        }

        var count = 0;
        var res = new int[k][];
        foreach (var pointDistance in pointDistanceSquares)
        {
            foreach (var pointIndex in dict[pointDistance])
            {
                res[count] = points[pointIndex];
                count++;
                if (count == k)
                {
                    return res;
                }
            }
        }
        return res;

    }

    private int LomutoPartition(int[] pointDistanceSquares, int start, int end)
    {
        // Optional
        var randomIndex = Random.Next(start, end);
        var temp2 = pointDistanceSquares[randomIndex];
        pointDistanceSquares[randomIndex] = pointDistanceSquares[end];
        pointDistanceSquares[end] = temp2;


        var pivot = pointDistanceSquares[end];
        var boundary = start;
        for (var i = start; i <= end - 1; i++)
        {
            if (pointDistanceSquares[i] < pivot)
            {
                var temp = pointDistanceSquares[i];
                pointDistanceSquares[i] = pointDistanceSquares[boundary];
                pointDistanceSquares[boundary] = temp;
                boundary++;
            }
        }

        temp2 = pointDistanceSquares[end];
        pointDistanceSquares[end] = pointDistanceSquares[boundary];
        pointDistanceSquares[boundary] = temp2;

        return boundary;
    }

    private int HoarePartition(int[] pointDistanceSquares, int start, int end)
    {
        var pivotIndex = start + (end - start) / 2;
        var pivot = pointDistanceSquares[pivotIndex];
        var boundaryLeft = start;
        var boundaryRight = end;
        while (boundaryLeft <= boundaryRight)
        {
            if (pointDistanceSquares[boundaryLeft] < pivot)
            {
                boundaryLeft++;
            }
            else if (pointDistanceSquares[boundaryRight] >= pivot)
            {
                boundaryRight--;
            }
            else
            {
                if (boundaryLeft == pivotIndex)
                {
                    pivotIndex = boundaryRight;
                }

                var temp = pointDistanceSquares[boundaryLeft];
                pointDistanceSquares[boundaryLeft] = pointDistanceSquares[boundaryRight];
                pointDistanceSquares[boundaryRight] = temp;
                boundaryLeft++;
                boundaryRight--;
            }

        }

        var temp2 = pointDistanceSquares[pivotIndex];
        pointDistanceSquares[pivotIndex] = pointDistanceSquares[boundaryLeft];
        pointDistanceSquares[boundaryLeft] = temp2;

        return boundaryLeft;
    }
}