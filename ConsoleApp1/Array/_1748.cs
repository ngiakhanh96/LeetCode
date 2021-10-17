namespace ConsoleApp1.Array;

public class _1748
{
    public int SumOfUnique(int[] nums)
    {
        var sum = 0;
        var dict = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (!dict.TryAdd(num, 1))
            {
                if (dict[num] == 1)
                {
                    sum -= num;
                }
                dict[num]++;
            }
            else
            {
                sum += num;
            }
        }
        return sum;
    }
}