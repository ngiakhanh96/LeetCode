namespace ConsoleApp1.PrefixSum
{
    public class _56
    {
        public int[][] Merge(int[][] intervals)
        {
            var maxTimeSpot = intervals.Select(p => p[1]).Max();
            var mergedInterval = new int[maxTimeSpot + 1];
            foreach (var interval in intervals)
            {
                mergedInterval[interval[0]]++;
                if (interval[1] + 1 < mergedInterval.Length)
                {
                    mergedInterval[interval[1] + 1]--;
                }
            }

            for (var i = 1; i < mergedInterval.Length; i++)
            {
                mergedInterval[i] += mergedInterval[i - 1];
            }

            var res = new List<int[]>();

            foreach (var interval in intervals)
            {
                if (mergedInterval[interval[0]] == 1 && mergedInterval[interval[1]] == 1)
                {
                    res.Add(interval);
                    for (var i = interval[0]; i <= interval[1]; i++)
                    {
                        mergedInterval[i] = 0;
                    }
                }
            }

            var currentInterval = new int[2];
            var startInterval = false;
            for (var i = 0; i < mergedInterval.Length; i++)
            {
                if (mergedInterval[i] > 0 && !startInterval)
                {
                    startInterval = true;
                    currentInterval[0] = i;
                }
                else if (mergedInterval[i] == 0 && startInterval)
                {
                    startInterval = false;
                    currentInterval[1] = i - 1;
                    res.Add(currentInterval);
                    currentInterval = new int[2];
                }
            }

            if (startInterval)
            {
                currentInterval[1] = mergedInterval.Length - 1;
                res.Add(currentInterval);
            }

            return res.ToArray();
        }
    }
}
