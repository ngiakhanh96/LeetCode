namespace ConsoleApp1.Array;

public class _327
{
    public int CountRangeSum(int[] nums, int lower, int upper)
    {
        var count = 0;
        var prefixSum = new long[nums.Length + 1];
        for (int i = 0; i < nums.Length; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        }

        MergeSort(prefixSum, ref count, lower, upper);
        return count;
    }

    private long[] MergeSort(long[] nums, ref int count, int lower, int upper)
    {
        if (nums.Length == 1)
        {
            return new long[] { nums[0] };
        }
        var left = MergeSort(nums[..(nums.Length / 2)], ref count, lower, upper);
        var right = MergeSort(nums[(nums.Length / 2)..], ref count, lower, upper);

        return Merge(left, right, ref count, lower, upper);
    }

    private long[] Merge(long[] left, long[] right, ref int count, int lower, int upper)
    {
        var i = 0;
        var j = 0;
        var res = new long[left.Length + right.Length];
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

        var j1 = 0;
        var j2 = 0;
        var stop = false;
        for (int l = 0; l < left.Length; l++)
        {
            while (right[j1] - left[l] < lower)
            {
                j1++;
                if (j1 == right.Length)
                {
                    stop = true;
                    break;
                }
            }

            if (stop)
            {
                break;
            }

            while (right[j2] - left[l] < upper)
            {
                j2++;
                if (j2 == right.Length)
                {
                    j2 = right.Length - 1;
                    break;
                }
            }

            while (j2 < right.Length - 1 && right[j2] == right[j2 + 1] && right[j2] - left[l] <= upper)
            {
                j2++;
                if (j2 == right.Length)
                {
                    j2 = right.Length - 1;
                    break;
                }
            }

            if (right[j1] - left[l] <= upper)
            {
                count += right[j2] - left[l] <= upper ? j2 - j1 + 1 : j2 - j1;
            }

        }

        return res;
    }
}