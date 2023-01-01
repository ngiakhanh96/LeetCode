namespace ConsoleApp1.HashTable;

public class _438
{
    public IList<int> FindAnagrams(string s, string p)
    {
        var result = new List<int>();
        if (s.Length < p.Length)
        {
            return result;
        }
        var pCharToFreqDict = new Dictionary<char, int>();
        var currentCharToFreqDict = new Dictionary<char, int>();
        var missingCharacters = new HashSet<char>();
        var neededToRemoveCharacters = new HashSet<char>();
        foreach (var chr in p)
        {
            if (!pCharToFreqDict.TryAdd(chr, 1))
            {
                pCharToFreqDict[chr]++;
            }
            currentCharToFreqDict.TryAdd(chr, 0);
            missingCharacters.Add(chr);
        }

        var queue = new Queue<char>();
        for (var i = 0; i < s.Length; i++)
        {
            var chr = s[i];
            queue.Enqueue(chr);
            if (currentCharToFreqDict.ContainsKey(chr))
            {
                currentCharToFreqDict[chr]++;
                if (currentCharToFreqDict[chr] == pCharToFreqDict[chr])
                {
                    missingCharacters.Remove(chr);
                }
                else if (currentCharToFreqDict[chr] > pCharToFreqDict[chr])
                {
                    neededToRemoveCharacters.Add(chr);
                }
            }

            if (queue.Count > p.Length)
            {
                var dequeuedChar = queue.Dequeue();
                if (currentCharToFreqDict.ContainsKey(dequeuedChar))
                {
                    currentCharToFreqDict[dequeuedChar]--;
                    if (currentCharToFreqDict[dequeuedChar] == pCharToFreqDict[dequeuedChar])
                    {
                        neededToRemoveCharacters.Remove(dequeuedChar);
                    }
                    else if (currentCharToFreqDict[dequeuedChar] < pCharToFreqDict[dequeuedChar])
                    {
                        missingCharacters.Add(dequeuedChar);
                    }
                }
            }

            if (queue.Count >= p.Length)
            {
                if (missingCharacters.Count == 0 && neededToRemoveCharacters.Count == 0)
                {
                    result.Add(i - (p.Length - 1));
                }
            }
        }
        return result;
    }
}