namespace ConsoleApp1.TwoPointers.Opposite;

public class _1471
{
    public int[] GetStrongest(int[] arr, int k)
    {
        // First quickselect to find median
        var middleIndex = (arr.Length - 1) / 2;
        var start = 0;
        var end = arr.Length - 1;
        var boundary = -1;
        while (boundary != middleIndex)
        {
            if (boundary < middleIndex)
            {
                start = boundary + 1;
            }
            else
            {
                end = boundary - 1;
            }
            boundary = LomutoPartitionToFindMedian(arr, start, end);
        }
        var median = arr[boundary];

        // Second quickselect to find kth strongest value
        k--;
        start = 0;
        end = arr.Length - 1;
        boundary = -1;
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
            boundary = LomutoPartitionToFindStrongestValues(arr, start, end, median);
        }
        var result = new int[boundary + 1];
        for (var i = 0; i <= boundary; i++)
        {
            result[i] = arr[i];
        }
        return result;
    }

    private int LomutoPartitionToFindMedian(int[] arr, int start, int end)
    {
        var boundary = start;
        var pivot = arr[end];
        for (var i = start; i < end; i++)
        {
            if (arr[i] < pivot)
            {
                var temp = arr[i];
                arr[i] = arr[boundary];
                arr[boundary++] = temp;
            }
        }

        var temp2 = arr[end];
        arr[end] = arr[boundary];
        arr[boundary] = temp2;

        return boundary;
    }

    private int LomutoPartitionToFindStrongestValues(int[] arr, int start, int end, int median)
    {
        var boundary = start;
        var pivot = arr[end];
        for (var i = start; i < end; i++)
        {
            if (Math.Abs(arr[i] - median) > Math.Abs(pivot - median) ||
            (Math.Abs(arr[i] - median) == Math.Abs(pivot - median) && arr[i] > pivot))
            {
                var temp = arr[i];
                arr[i] = arr[boundary];
                arr[boundary++] = temp;
            }
        }

        var temp2 = arr[end];
        arr[end] = arr[boundary];
        arr[boundary] = temp2;

        return boundary;
    }

    public int[] GetStrongest2(int[] arr, int k)
    {
        var res = new int[k];
        System.Array.Sort(arr);
        var count = 0;
        var i = 0;
        var j = arr.Length - 1;
        var median = arr[(arr.Length - 1) / 2];
        while (count < k)
        {
            var distanceI = Math.Abs(arr[i] - median);
            var distanceJ = Math.Abs(arr[j] - median);

            if (distanceI > distanceJ)
            {
                res[count] = arr[i];
                i++;
            }
            else if (distanceI < distanceJ)
            {
                res[count] = arr[j];
                j--;
            }
            else
            {
                if (arr[i] > arr[j])
                {
                    res[count] = arr[i];
                    i++;
                }
                else
                {
                    res[count] = arr[j];
                    j--;
                }
            }

            count++;
        }

        return res;
    }
}