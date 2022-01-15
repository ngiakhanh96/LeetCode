namespace ConsoleApp1.Array
{
    public class _56
    {
        public int[][] Merge(int[][] intervals)
        {
            System.Array.Sort(intervals, (a, b) => a[0] - b[0]);
            var res = new List<int[]> { intervals[0] };

            for (int i = 1; i < intervals.Length; i++)
            {
                var interval = intervals[i];
                var previousInterval = res[res.Count - 1];
                if (interval[0] <= previousInterval[1])
                {
                    res.RemoveAt(res.Count - 1);
                    res.Add(new int[] { previousInterval[0], Math.Max(previousInterval[1], interval[1]) });
                }
                else
                {
                    res.Add(interval);
                }
            }

            return res.ToArray();
        }
    }
}
