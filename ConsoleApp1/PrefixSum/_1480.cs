﻿namespace ConsoleApp1.PrefixSum;

public class _1480
{
    public int[] RunningSum(int[] nums)
    {
        var sum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            nums[i] = sum;
        }
        return nums;
    }
}