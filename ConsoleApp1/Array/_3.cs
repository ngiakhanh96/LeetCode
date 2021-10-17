namespace ConsoleApp1.Array;

public class _3
{
    public int LengthOfLongestSubstring(string s)
    {
        var hashset = new HashSet<char>();
        var max = 0;
        var currentJ = 0;
        var shouldContinue = false;
        for (int i = 0; i < s.Length; i++)
        {
            if (i > 0)
            {
                hashset.Remove(s[i - 1]);
                currentJ = i > currentJ ? i : currentJ;
            }

            for (int j = currentJ; j < s.Length; j++)
            {
                shouldContinue = false;
                if (!hashset.Add(s[j]))
                {
                    currentJ = j;
                    shouldContinue = true;
                    break;
                }
                max = hashset.Count > max ? hashset.Count : max;
            }

            if (!shouldContinue)
            {
                break;
            }
        }

        return max;
    }
}