namespace ConsoleApp1.BinarySearch;

[LastVisited(2022, 12, 20)]

// See https://leetcode.com/problems/divide-chocolate/discuss/411661/Python-binary-search-with-inline-explanation
// and the comments
public class _1231
{
    public int MaximizeSweetness(int[] sweetness, int k)
    {
        var minMinSweetness = sweetness.Min();
        var maxMinSweetness = sweetness.Sum() / (k + 1);

        while (minMinSweetness < maxMinSweetness)
        {
            var midMinSweetness = minMinSweetness + (maxMinSweetness - minMinSweetness + 1) / 2;
            var pieces = 0;
            var currentSumSingleSweetness = 0;
            foreach (var singleSweetness in sweetness)
            {
                currentSumSingleSweetness += singleSweetness;
                if (currentSumSingleSweetness >= midMinSweetness)
                {
                    pieces++;
                    currentSumSingleSweetness = 0;
                }
            }
            // the last piece if it is smaller than midMinSweetness, then we can combine it with the previous one, therefore no need to count it
            // maximum number of pieces which each has at least midMinSweetness
            // if the maximum number is still not enough, then some pieces will have to share their parts, which makes the minSweetness decrease
            if (pieces < k + 1)
            {
                maxMinSweetness = midMinSweetness - 1;
            }
            // otherwise in case we have more pieces than expected, we can combine them with the other pieces
            else
            {
                minMinSweetness = midMinSweetness;
            }
        }
        return minMinSweetness;
    }
}