﻿namespace ConsoleApp1.QuickSelect;

public class _922
{
    public int[] SortArrayByParityII(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums;
        }
        var lastPointer = 1;
        for (var i = 0; i < nums.Length; i += 2)
        {
            if (nums[i] % 2 != 0)
            {
                for (var j = lastPointer; j < nums.Length; j += 2)
                {
                    if (nums[j] % 2 == 0)
                    {
                        lastPointer = j;
                        var temp = nums[i];
                        nums[i] = nums[lastPointer];
                        nums[lastPointer] = temp;
                        break;
                    }
                }
            }
        }

        return nums;
    }
}