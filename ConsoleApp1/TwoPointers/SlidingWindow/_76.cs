namespace ConsoleApp1.TwoPointers.SlidingWindow;

// Super hard sliding window. See Youtube for explanation
public class _76
{
    public string MinWindow(string s, string t)
    {
        var tCharDict = new Dictionary<char, int>();
        foreach (var tChar in t)
        {
            if (!tCharDict.TryAdd(tChar, 1))
            {
                tCharDict[tChar]++;
            }
        }

        var numMissingChar = t.Length;
        var start = 0;
        var end = s.Length + 2;

        var slowPointer = 0;
        var fastPointer = 0;
        while (fastPointer < s.Length)
        {
            while (numMissingChar > 0 && fastPointer < s.Length)
            {
                if (tCharDict.ContainsKey(s[fastPointer]))
                {
                    tCharDict[s[fastPointer]]--;
                    if (tCharDict[s[fastPointer]] >= 0)
                    {
                        numMissingChar--;
                    }
                }

                fastPointer++;
            }

            if (numMissingChar < 1)
            {
                while (numMissingChar < 1)
                {
                    if (tCharDict.ContainsKey(s[slowPointer]))
                    {
                        tCharDict[s[slowPointer]]++;
                        if (tCharDict[s[slowPointer]] > 0)
                        {
                            numMissingChar++;
                        }
                    }

                    slowPointer++;
                }

                if (fastPointer - slowPointer < end - start)
                {
                    start = slowPointer;
                    end = fastPointer;
                }
            }
        }

        var res = "";
        if (end == s.Length + 2)
        {
            return res;
        }
        for (var i = start - 1; i < end; i++)
        {
            res += s[i];
        }

        return res;

    }
}