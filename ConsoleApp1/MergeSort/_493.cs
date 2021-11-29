namespace ConsoleApp1.MergeSort;

public class _493
{
    public int ReversePairs(int[] nums)
    {
        var count = 0;
        MergeSort(nums, ref count);
        return count;
    }

    private int[] MergeSort(int[] nums, ref int count)
    {
        if (nums.Length == 1)
        {
            return new int[] { nums[0] };
        }
        var left = MergeSort(nums[..(nums.Length / 2)], ref count);
        var right = MergeSort(nums[(nums.Length / 2)..], ref count);

        return Merge(left, right, ref count);
    }

    private int[] Merge(int[] left, int[] right, ref int count)
    {
        var i = 0;
        var j = 0;
        var res = new int[left.Length + right.Length];
        var k = 0;
        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
            {
                res[k++] = left[i++];
            }
            else
            {
                res[k++] = right[j++];
            }
        }

        while (i < left.Length)
        {
            res[k++] = left[i++];
        }

        while (j < right.Length)
        {
            res[k++] = right[j++];
        }

        i = 0;
        j = 0;
        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= (long)2 * right[j])
            {
                i++;
            }
            else
            {
                count += left.Length - i;
                j++;
            }
        }

        return res;
    }
}