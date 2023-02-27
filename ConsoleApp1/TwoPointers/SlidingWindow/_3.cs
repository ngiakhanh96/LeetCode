namespace ConsoleApp1.TwoPointers.SlidingWindow;

[LastVisited(2023, 02, 27)]
public class _3
{
    public int LengthOfLongestSubstring(string s)
    {
        var (l, r) = (0, 0);
        var charsHashSet = new HashSet<char>
        {
            s[l]
        };
        var res = 0;
        bool isRepeat = false;
        var repeatedChar = 'c';
        while (r < s.Length)
        {
            if (!isRepeat)
            {
                res = Math.Max(res, r - l + 1);
                r++;
                if (r < s.Length)
                {
                    if (!charsHashSet.Add(s[r]))
                    {
                        isRepeat = true;
                        repeatedChar = s[r];
                    }
                }
            }
            else
            {

                if (s[l] != repeatedChar)
                {
                    charsHashSet.Remove(s[l]);
                }
                else
                {
                    isRepeat = false;
                }
                l++;
            }
        }
        return res;
    }

    public int LengthOfLongestSubstring2(string s)
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