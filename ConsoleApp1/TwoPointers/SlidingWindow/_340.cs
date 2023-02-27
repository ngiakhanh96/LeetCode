namespace ConsoleApp1.TwoPointers.SlidingWindow;

[LastVisited(2023, 02, 27)]
public class _340
{
    public int LengthOfLongestSubstringKDistinct(string s, int k)
    {
        var res = 0;
        if (s.Length == 0)
        {
            return res;
        }
        var (l, r) = (0, 0);
        var charDict = new Dictionary<char, int>
        {
            { s[l], 1 }
        };
        while (r < s.Length)
        {
            if (charDict.Count <= k)
            {
                res = Math.Max(res, r - l + 1);
                r++;
                if (r < s.Length)
                {
                    if (!charDict.TryAdd(s[r], 1))
                    {
                        charDict[s[r]]++;
                    }
                }
            }
            else
            {
                if (charDict[s[l]] == 1)
                {
                    charDict.Remove(s[l]);
                }
                else
                {
                    charDict[s[l]]--;
                }
                l++;
            }
        }
        return res;
    }
}