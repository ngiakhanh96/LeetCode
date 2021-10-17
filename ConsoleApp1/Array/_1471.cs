namespace ConsoleApp1.Array;

public class _1471
{
    public int[] GetStrongest(int[] arr, int k)
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