namespace ConsoleApp1.Array
{
    // Based on _525
    public class _1124
    {
        public int LongestWPI(int[] hours)
        {
            var count = 0;
            var longestWPI = 0;
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < hours.Length; i++)
            {
                count += hours[i] > 8 ? 1 : -1;

                if (count > 0)
                {
                    longestWPI = i + 1;
                }
                else
                {
                    dict.TryAdd(count, i);
                    if (dict.ContainsKey(count - 1))
                    {
                        longestWPI = Math.Max(longestWPI, i - dict[count - 1]);
                    }
                }
            }

            return longestWPI;
        }
    }
}
