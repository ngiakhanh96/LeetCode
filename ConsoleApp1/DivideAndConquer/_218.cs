namespace ConsoleApp1.DivideAndConquer;
public class _218
{
    public IList<IList<int>> GetSkyline(int[][] buildings)
    {
        return Divide(0, buildings.Length, buildings);
    }

    private IList<IList<int>> Divide(int start, int end, int[][] buildings)
    {
        if (end - start <= 1)
        {
            return new List<IList<int>>{
                new List<int>{
                    buildings[start][0],
                    buildings[start][2]
                },
                new List<int>{
                    buildings[start][1],
                    0
                }
            };
        }

        var left = Divide(start, start + (end - start) / 2, buildings);
        var right = Divide(start + (end - start) / 2, end, buildings);
        var res = new List<IList<int>>();

        var leftPointer = 0;
        var rightPointer = 0;
        while (leftPointer < left.Count && rightPointer < right.Count)
        {
            if (left[leftPointer][0] < right[rightPointer][0])
            {
                if ((left[leftPointer][1] > 0 && (!res.Any() || left[leftPointer][1] > res[^1][1])) || left[leftPointer][0] < right[0][0] || left[leftPointer][0] > right[^1][0])
                {
                    res.Add(new List<int> { left[leftPointer][0], left[leftPointer][1] });
                }
                else if (left[leftPointer][1] == 0)
                {
                    res.Add(new List<int> { left[leftPointer][0], right[rightPointer - 1][1] });
                }

                leftPointer++;
                continue;
            }
            if (left[leftPointer][0] > right[rightPointer][0])
            {
                if ((right[rightPointer][1] > 0 && (!res.Any() || right[rightPointer][1] > res[^1][1])) || right[rightPointer][0] > left[^1][0])
                {
                    res.Add(new List<int> { right[rightPointer][0], right[rightPointer][1] });
                }
                else if (right[rightPointer][1] == 0)
                {
                    res.Add(new List<int> { right[rightPointer][0], left[leftPointer - 1][1] });
                }
                rightPointer++;
                continue;
            }
            if (left[leftPointer][1] > right[rightPointer][1])
            {
                if ((left[leftPointer][1] > 0 && (!res.Any() || left[leftPointer][1] > res[^1][1])) || left[leftPointer][0] < right[0][0] || left[leftPointer][0] > right[^1][0])
                {
                    res.Add(new List<int> { left[leftPointer][0], left[leftPointer][1] });
                }
                else if (left[leftPointer][1] == 0)
                {
                    res.Add(new List<int> { left[leftPointer][0], right[rightPointer - 1][1] });
                }
            }
            else
            {
                if ((right[rightPointer][1] > 0 && (!res.Any() || right[rightPointer][1] > res[^1][1])) || right[rightPointer][0] > left[-1][0])
                {
                    res.Add(new List<int> { right[rightPointer][0], right[rightPointer][1] });
                }
                else if (right[rightPointer][1] == 0)
                {
                    res.Add(new List<int> { right[rightPointer][0], left[leftPointer - 1][1] });
                }
            }

            rightPointer++;
            leftPointer++;
        }

        while (leftPointer < left.Count)
        {
            res.Add(new List<int> { left[leftPointer][0], left[leftPointer][1] });
            leftPointer++;
        }

        while (rightPointer < right.Count)
        {
            res.Add(new List<int> { right[rightPointer][0], right[rightPointer][1] });
            rightPointer++;
        }


        return res;

    }
}