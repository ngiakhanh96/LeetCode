namespace ConsoleApp1.HashTable;

[LastVisited(2022, 11, 20)]
public class _266
{
    public bool CanPermutePalindrome(string s)
    {
        var hashSet = new HashSet<char>();
        foreach (var c in s)
        {
            if (!hashSet.Add(c))
            {
                hashSet.Remove(c);
            }
        }

        return hashSet.Count < 2;
    }
}