﻿namespace ConsoleApp1.HashTable;

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