namespace ConsoleApp1.TwoPointers.SlidingWindow;

[LastVisited(2023, 02, 27)]
public class _904
{
    public int TotalFruit(int[] fruits)
    {
        var res = 0;
        if (fruits.Length == 0)
        {
            return res;
        }
        var (l, r) = (0, 0);
        var charDict = new Dictionary<int, int> { { fruits[l], 1 } };
        while (r < fruits.Length)
        {
            if (charDict.Count <= 2)
            {
                res = Math.Max(res, r - l + 1);
                r++;
                if (r < fruits.Length)
                {
                    if (!charDict.TryAdd(fruits[r], 1))
                    {
                        charDict[fruits[r]]++;
                    }
                }
            }
            else
            {
                if (charDict[fruits[l]] == 1)
                {
                    charDict.Remove(fruits[l]);
                }
                else
                {
                    charDict[fruits[l]]--;
                }
                l++;
            }
        }
        return res;
    }
}