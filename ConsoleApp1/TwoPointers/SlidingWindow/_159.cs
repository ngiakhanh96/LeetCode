namespace ConsoleApp1.TwoPointers.SlidingWindow;

[LastVisited(2023, 02, 27)]
public class _159
{
    public int LengthOfLongestSubstringTwoDistinct(string s)
    {
        var (l, r) = (0, 0);
        var distinctCharsDict = new Dictionary<char, int> { { s[0], 1 } };
        var res = 0;
        while (r < s.Length)
        {
            if (distinctCharsDict.Count <= 2)
            {
                res = Math.Max(res, r - l + 1);
                r++;
                if (r < s.Length)
                {
                    if (!distinctCharsDict.TryAdd(s[r], 1))
                    {
                        distinctCharsDict[s[r]]++;
                    }
                }
            }
            else
            {
                distinctCharsDict[s[l]]--;
                if (distinctCharsDict[s[l]] <= 0)
                {
                    distinctCharsDict.Remove(s[l]);
                }
                l++;
            }
        }
        return res;
    }
}