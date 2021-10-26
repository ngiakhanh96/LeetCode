﻿namespace ConsoleApp1.Array;

public class _33
{
    public int Search(int[] nums, int target, int start = 0, int end = int.MaxValue)
    {
        if (end == int.MaxValue)
        {
            end = nums.Length - 1;
        }
        if (start >= end)
        {
            return nums[start] == target ? start : -1;
        }

        var middleEleIndex = (start + end) / 2;
        if (target == nums[middleEleIndex])
        {
            return middleEleIndex;
        }
        if (nums[start] < nums[end])
        {

            if (target > nums[middleEleIndex] && target <= nums[end])
            {
                return Search(
                    nums,
                    target,
                    middleEleIndex + 1,
                    end
                );
            }
            if (target < nums[middleEleIndex])
            {
                return Search(
                    nums,
                    target,
                    start,
                    middleEleIndex - 1
                );
            }
        }
        else
        {
            if (nums[end] > nums[middleEleIndex])
            {
                if (target > nums[middleEleIndex] && target <= nums[end])
                {
                    return Search(
                        nums,
                        target,
                        middleEleIndex + 1,
                        end
                    );
                }

                if (target < nums[middleEleIndex] || target >= nums[end])
                {
                    return Search(
                        nums,
                        target,
                        start,
                        middleEleIndex - 1
                    );
                }
            }

            else
            {
                if (target > nums[middleEleIndex] || target <= nums[end])
                {
                    return Search(
                        nums,
                        target,
                        middleEleIndex + 1,
                        end
                    );
                }
                if (target < nums[middleEleIndex] && target >= nums[end])
                {
                    return Search(
                        nums,
                        target,
                        start,
                        middleEleIndex - 1
                    );
                }
            }
        }
        return -1;
    }
}