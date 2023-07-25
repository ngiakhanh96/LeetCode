namespace ConsoleApp1.HashTable;

[LastVisited(2023, 07, 25)]
public class _217
{
    public bool ContainsDuplicate(int[] nums)
    {
        var hashset = new HashSet<int>();
        foreach (var i in nums)
        {
            if (hashset.Contains(i))
            {
                return true;
            }

            hashset.Add(i);
        }
        return false;
    }
}