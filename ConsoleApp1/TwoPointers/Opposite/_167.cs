﻿namespace ConsoleApp1.TwoPointers.Opposite;

[LastVisited(2023, 07, 25)]
public class _167
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var firstPointer = 0;
        var secondPointer = numbers.Length - 1;
        while (secondPointer > firstPointer)
        {
            if (numbers[firstPointer] + numbers[secondPointer] == target)
            {
                return new[] { firstPointer + 1, secondPointer + 1 };
            }

            if (numbers[firstPointer] + numbers[secondPointer] > target)
            {
                secondPointer--;
            }
            else
            {
                firstPointer++;
            }
        }

        return new[] { 0, 0 };
    }

    public int[] TwoSum2(int[] numbers, int target)
    {
        var leftPointer = 0;
        var rightPointer = numbers.Length - 1;
        while (numbers[leftPointer] + numbers[rightPointer] != target)
        {
            if (numbers[leftPointer] + numbers[rightPointer] < target)
            {
                leftPointer++;
            }
            else
            {
                rightPointer--;
            }
        }

        return new[] { leftPointer + 1, rightPointer + 1 };
    }
}