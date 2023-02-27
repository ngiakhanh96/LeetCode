using System.Text;

namespace ConsoleApp1.TwoPointers.SlidingWindow;

[LastVisited(2023, 02, 27)]
public class _76
{
    public string MinWindow(string s, string t)
    {
        if (s.Length == 0)
        {
            return "";
        }
        var (l, r) = (0, 0);
        var targetCharToFrequencyDict = new Dictionary<char, int>();
        var currentCharToFrequencyDict = new Dictionary<char, int>();
        foreach (var c in t)
        {
            if (!targetCharToFrequencyDict.TryAdd(c, 1))
            {
                targetCharToFrequencyDict[c]++;
            }
            currentCharToFrequencyDict.TryAdd(c, 0);
        }
        var minCount = int.MaxValue;
        var numOfMissingChars = targetCharToFrequencyDict.Count;
        var (minL, minR) = (-1, -1);
        if (currentCharToFrequencyDict.ContainsKey(s[r]))
        {
            currentCharToFrequencyDict[s[r]]++;
            if (currentCharToFrequencyDict[s[r]] == targetCharToFrequencyDict[s[r]])
            {
                numOfMissingChars--;
            }
        }

        while (r < s.Length && l < s.Length)
        {
            if (numOfMissingChars == 0)
            {
                var count = r - l + 1;
                if (count < minCount)
                {
                    minL = l;
                    minR = r;
                    minCount = count;
                }
                if (currentCharToFrequencyDict.ContainsKey(s[l]))
                {
                    currentCharToFrequencyDict[s[l]]--;
                    if (currentCharToFrequencyDict[s[l]] == targetCharToFrequencyDict[s[l]] - 1)
                    {
                        numOfMissingChars++;
                    }
                }
                l++;
            }
            else
            {
                r++;
                if (r < s.Length)
                {
                    if (currentCharToFrequencyDict.ContainsKey(s[r]))
                    {
                        currentCharToFrequencyDict[s[r]]++;
                        if (currentCharToFrequencyDict[s[r]] == targetCharToFrequencyDict[s[r]])
                        {
                            numOfMissingChars--;
                        }
                    }
                }
            }
        }

        if (minL == -1)
        {
            return "";
        }
        var stringBuilder = new StringBuilder();
        for (var i = minL; i <= minR; i++)
        {
            stringBuilder.Append(s[i]);
        }
        return stringBuilder.ToString();
    }
}