﻿namespace ConsoleApp1.HashTable;

public class _387
{
    public int FirstUniqChar(string s)
    {
        var dict = new Dictionary<char, int>();
        foreach (var c in s)
        {
            if (!dict.TryAdd(c, 1))
            {
                dict[c]++;
            }
        }

        for (var i = 0; i < s.Length; i++)
        {
            if (dict[s[i]] == 1)
            {
                return i;
            }
        }
        return -1;
    }
}