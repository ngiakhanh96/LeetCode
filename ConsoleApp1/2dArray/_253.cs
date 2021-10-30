namespace ConsoleApp1._2dArray;

public class _253
{
    public int MinMeetingRooms(int[][] intervals)
    {
        var dict = new Dictionary<int, int>();
        var arr = Set(dict, intervals);
        var sum = 0;
        var max = 0;
        foreach (var value in arr)
        {
            sum += dict[value];
            max = sum > max ? sum : max;
        }

        return max;
    }

    private int[] Set(Dictionary<int, int> dict, int[][] intervals)
    {
        foreach (var interval in intervals)
        {
            if (!dict.TryAdd(interval[0], 1))
            {
                dict[interval[0]]++;
            }

            if (!dict.TryAdd(interval[1], -1))
            {
                dict[interval[1]]--;
            }
        }

        var res = dict.Keys.ToArray();
        System.Array.Sort(res);
        return res;
    }
}