namespace ConsoleApp1.TwoPointers.SlidingWindow;

public class _159
{
    public int LengthOfLongestSubstringTwoDistinct(string s)
    {
        var currentJ = 0;
        var dict = new Dictionary<int, int>();
        var maxLength = 0;
        var shouldContinue = true;
        for (var i = 0; i < s.Length; i++)
        {
            if (i > 0)
            {
                if (dict.ContainsKey(s[i - 1]))
                {
                    if (dict[s[i - 1]] == 1)
                    {
                        dict.Remove(s[i - 1]);
                    }
                    else
                    {
                        dict[s[i - 1]]--;
                    }
                }
                currentJ = i > currentJ ? i : currentJ;
            }

            for (var j = currentJ; j < s.Length; j++)
            {
                if (!dict.TryAdd(s[j], 1))
                {
                    dict[s[j]]++;
                }

                else if (dict.Count > 2)
                {
                    currentJ = j;
                    dict.Remove(s[j]);
                    break;
                }
                maxLength = j - i + 1 > maxLength ? j - i + 1 : maxLength;
                if (j + 1 >= s.Length)
                {
                    shouldContinue = false;
                }
            }

            if (!shouldContinue)
            {
                break;
            }
        }

        return maxLength;
    }
}