namespace ConsoleApp1._2dArray;

public class _973
{
    public int[][] KClosest(int[][] points, int k)
    {
        var dict = new Dictionary<int, HashSet<int>>();
        var pointDistanceSquare = new int[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            var distanceSquare = points[i][0] * points[i][0] + points[i][1] * points[i][1];
            if (!dict.TryAdd(distanceSquare, new HashSet<int> { i }))
            {
                dict[distanceSquare].Add(i);
            }

            pointDistanceSquare[i] = distanceSquare;
        }

        var kClosestDistance = KClosestDistance(pointDistanceSquare, k);
        var res = new int[k][];
        var j = 0;
        var shouldContinue = true;
        for (int i = 0; i < k; i++)
        {
            var distance = pointDistanceSquare[i];
            foreach (var index in dict[distance])
            {
                res[j] = points[index];
                j++;
                if (j >= k)
                {
                    shouldContinue = false;
                    break;
                }
            }

            if (!shouldContinue)
            {
                break;
            }
        }

        return res;
    }

    private int KClosestDistance(int[] pointDistanceSquare, int k, int fromIndex = 0, int endIndexPlusOne = -1)
    {
        if (endIndexPlusOne < 0)
        {
            endIndexPlusOne = pointDistanceSquare.Length;
        }

        if (endIndexPlusOne - fromIndex < 2)
        {
            return pointDistanceSquare[fromIndex];
        }

        var randomIndex = new Random().Next(fromIndex, endIndexPlusOne - 1);
        Swap(pointDistanceSquare, randomIndex, endIndexPlusOne - 1);

        var pivot = pointDistanceSquare[endIndexPlusOne - 1];
        var boundary = fromIndex;
        for (int i = fromIndex; i < endIndexPlusOne - 1; i++)
        {
            if (pointDistanceSquare[i] < pivot)
            {
                Swap(pointDistanceSquare, i, boundary);
                boundary++;
            }
        }

        Swap(pointDistanceSquare, endIndexPlusOne - 1, boundary);
        if (boundary == fromIndex + k - 1)
        {
            return pointDistanceSquare[boundary];
        }

        if (boundary > fromIndex + k - 1)
        {
            return KClosestDistance(pointDistanceSquare, k, fromIndex, boundary);
        }

        return KClosestDistance(pointDistanceSquare, k - (boundary + 1 - fromIndex), boundary + 1, endIndexPlusOne);
    }

    private void Swap(int[] arr, int left, int right)
    {
        var temp = arr[left];
        arr[left] = arr[right];
        arr[right] = temp;
    }
}