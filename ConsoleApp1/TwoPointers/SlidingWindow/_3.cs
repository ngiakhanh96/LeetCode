namespace ConsoleApp1.TwoPointers.SlidingWindow;

public class _3
{
    public int LengthOfLongestSubstring(string s)
    {
        var hashset = new HashSet<char>();
        var max = 0;
        var currentJ = 0;
        var shouldContinue = true;
        for (var i = 0; i < s.Length; i++)
        {
            if (i > 0)
            {
                hashset.Remove(s[i - 1]);
                currentJ = i > currentJ ? i : currentJ;
            }

            for (var j = currentJ; j < s.Length; j++)
            {
                if (!hashset.Add(s[j]))
                {
                    currentJ = j;
                    break;
                }
                max = hashset.Count > max ? hashset.Count : max;
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

        return max;
    }
}