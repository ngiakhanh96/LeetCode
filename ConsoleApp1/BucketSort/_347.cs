﻿namespace ConsoleApp1.BucketSort;

public class _347
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (!dict.TryAdd(num, 1))
            {
                dict[num]++;
            }
        }
        var countingArr = new List<int>[nums.Length + 1];
        foreach (var (key, value) in dict)
        {
            if (countingArr[value] == null)
            {
                countingArr[value] = new List<int> { key };
            }
            else
            {
                countingArr[value].Add(key);
            }
        }

        var count = 0;
        var res = new int[k];
        for (var i = countingArr.Length - 1; i >= 0; i--)
        {
            if (countingArr[i] != null)
            {
                var j = 0;
                while (count < k && j < countingArr[i].Count)
                {
                    res[count] = countingArr[i][j];
                    j++;
                    count++;
                }

            }

            if (count == k)
            {
                break;
            }
        }
        return res;
    }

    public int[] TopKFrequent2(int[] nums, int k)
    {

        var numToFreqDict = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (!numToFreqDict.TryAdd(num, 1))
            {
                numToFreqDict[num]++;
            }
        }
        var maxHeap = new MaxPriorityQueue<int, int>(numToFreqDict.Count);
        var freqToNumsDict = new Dictionary<int, List<int>>();
        foreach (var (key, value) in numToFreqDict)
        {
            if (!freqToNumsDict.TryAdd(value, new List<int> { key }))
            {
                freqToNumsDict[value].Add(key);
            }


        }

        foreach (var freq in freqToNumsDict.Keys)
        {
            maxHeap.Enqueue(freq);
        }

        var count = 0;
        var res = new int[k];
        while (count < k)
        {
            var freq = maxHeap.Dequeue();
            var numList = freqToNumsDict[freq];
            var j = 0;
            while (count < k && j < numList.Count)
            {
                res[count] = numList[j];
                j++;
                count++;
            }
        }
        return res;
    }

    public int[] TopKFrequent3(int[] nums, int k)
    {
        var maxHeap = new MaxPriorityQueue<int, int>();
        var numToFreqDict = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (!numToFreqDict.TryAdd(num, 1))
            {
                numToFreqDict[num]++;
            }
        }

        var freqToNumsDict = new Dictionary<int, List<int>>();
        foreach (var (key, value) in numToFreqDict)
        {
            if (!freqToNumsDict.TryAdd(value, new List<int> { key }))
            {
                freqToNumsDict[value].Add(key);
            }


        }

        foreach (var freq in freqToNumsDict.Keys)
        {
            maxHeap.Enqueue(freq);
        }

        var count = 0;
        var res = new int[k];
        while (count < k)
        {
            var freq = maxHeap.Dequeue();
            var numList = freqToNumsDict[freq];
            var j = 0;
            while (count < k && j < numList.Count)
            {
                res[count] = numList[j];
                j++;
                count++;
            }
        }
        return res;
    }
}