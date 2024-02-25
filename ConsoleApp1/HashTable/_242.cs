namespace ConsoleApp1.HashTable;

[LastVisited(2023, 08, 16)]
public class _242
{
    public bool IsAnagram(string s, string t)
    {
        var dict = new Dictionary<char, int>();
        foreach (var chr in s)
        {
            if (!dict.TryAdd(chr, 1))
            {
                dict[chr]++;
            }
        }

        foreach (var chr in t)
        {
            if (!dict.ContainsKey(chr))
            {
                return false;
            }

            dict[chr]--;
            if (dict[chr] == 0)
            {
                dict.Remove(chr);
            }
        }

        return dict.Count == 0 ? true : false;
    }
}