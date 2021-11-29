namespace ConsoleApp1.HashTable;

public class _266
{
    public bool CanPermutePalindrome(string s)
    {
        var hashSet = new HashSet<char>();
        foreach (var c in s)
        {
            if (!hashSet.Contains(c))
            {
                hashSet.Add(c);
            }
            else
            {
                hashSet.Remove(c);
            }
        }

        return hashSet.Count < 2;
    }
}