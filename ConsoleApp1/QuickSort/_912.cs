namespace ConsoleApp1.QuickSort;

public class _912
{
    //Merge sort
    public int[] SortArray(int[] nums, int start = 0, int end = -2)
    {
        if (end == -2)
        {
            end = nums.Length - 1;
        }

        if (end - start <= 0)
        {
            return nums;
        }

        var middle = (end - start) / 2 + start;
        SortArray(nums, start, middle);
        SortArray(nums, middle + 1, end);
        Merge(nums, start, middle, end);
        return nums;
    }

    private void Merge(int[] nums, int start, int middle, int end)
    {
        var leftArr = new int[middle - start + 1];
        var rightArr = new int[end - (middle + 1) + 1];

        for (var i = start; i <= middle; i++)
        {
            leftArr[i - start] = nums[i];
        }

        for (var i = middle + 1; i <= end; i++)
        {
            rightArr[i - (middle + 1)] = nums[i];
        }

        var leftPointer = 0;
        var rightPointer = 0;
        var mainPointer = start;
        while (leftPointer < leftArr.Length || rightPointer < rightArr.Length)
        {
            if (leftPointer >= leftArr.Length)
            {
                nums[mainPointer++] = rightArr[rightPointer++];
                continue;
            }
            if (rightPointer >= rightArr.Length)
            {
                nums[mainPointer++] = leftArr[leftPointer++];
                continue;
            }

            if (leftArr[leftPointer] <= rightArr[rightPointer])
            {
                nums[mainPointer++] = leftArr[leftPointer++];
            }
            else
            {
                nums[mainPointer++] = rightArr[rightPointer++];
            }
        }
    }

    // Quicksort
    public int[] SortArray2(int[] nums, int start = 0, int end = -2)
    {
        if (end == -2)
        {
            end = nums.Length - 1;
        }

        if (end - start <= 0)
        {
            return nums;
        }

        var pivot = nums[end];
        var boundary = start;
        for (var i = start; i < end; i++)
        {
            if (nums[i] < pivot)
            {
                var temp = nums[i];
                nums[i] = nums[boundary];
                nums[boundary++] = temp;
            }
        }

        var temp2 = nums[end];
        nums[end] = nums[boundary];
        nums[boundary] = temp2;

        SortArray(nums, start, boundary - 1);
        SortArray(nums, boundary + 1, end);
        return nums;
    }
}