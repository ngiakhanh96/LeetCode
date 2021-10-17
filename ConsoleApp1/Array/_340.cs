namespace ConsoleApp1.Array;

public class _340
{
    public int LengthOfLongestSubstringKDistinct(string s, int k)
    {
        var currentJ = 0;
        var dict = new Dictionary<int, int>();
        var maxLength = 0;
        var shouldContinue = false;
        for (int i = 0; i < s.Length; i++)
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

            for (int j = currentJ; j < s.Length; j++)
            {
                shouldContinue = false;
                if (!dict.TryAdd(s[j], 1))
                {
                    dict[s[j]]++;
                }

                else if (dict.Count > k)
                {
                    currentJ = j;
                    dict.Remove(s[j]);
                    shouldContinue = true;
                    break;
                }
                maxLength = j - i + 1 > maxLength ? j - i + 1 : maxLength;
            }

            if (!shouldContinue)
            {
                break;
            }
        }

        return maxLength;
    }
}