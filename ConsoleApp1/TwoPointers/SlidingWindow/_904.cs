namespace ConsoleApp1.TwoPointers.SlidingWindow;

public class _904
{
    public int TotalFruit(int[] fruits)
    {
        var dict = new Dictionary<int, int>();
        var max = 0;
        var currentJ = 0;
        var shouldContinue = true;
        for (var i = 0; i < fruits.Length; i++)
        {
            if (i > 0)
            {
                if (dict.ContainsKey(fruits[i - 1]))
                {
                    dict[fruits[i - 1]]--;
                    if (dict[fruits[i - 1]] == 0)
                    {
                        dict.Remove(fruits[i - 1]);
                    }
                }

                currentJ = i > currentJ ? i : currentJ;
            }

            for (var j = currentJ; j < fruits.Length; j++)
            {
                if (dict.TryAdd(fruits[j], 1))
                {
                    if (dict.Count > 2)
                    {
                        currentJ = j;
                        dict.Remove(fruits[j]);
                        break;
                    }
                }
                else
                {
                    dict[fruits[j]]++;
                }
                max = j - i + 1 > max ? j - i + 1 : max;
                if (j + 1 >= fruits.Length)
                {
                    shouldContinue = false;
                }
            }

            if (!shouldContinue)
            {
                break;
            }
        }

        return max;
    }
}