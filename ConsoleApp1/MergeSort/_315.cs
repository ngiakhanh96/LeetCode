namespace ConsoleApp1.MergeSort;

public class _315
{
    public class ValueWithOriginalIndex
    {
        public int OriginalIndex { get; set; }

        public int Value { get; set; }
    }

    public IList<int> CountSmaller(int[] nums)
    {
        var res = new int[nums.Length];
        var valueWithOriginalIndex = new ValueWithOriginalIndex[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            valueWithOriginalIndex[i] = new ValueWithOriginalIndex
            {
                OriginalIndex = i,
                Value = nums[i]
            };
        }

        MergeSort(valueWithOriginalIndex, res);
        return res.ToList();
    }

    private ValueWithOriginalIndex[] MergeSort(ValueWithOriginalIndex[] nums, int[] resultList)
    {
        if (nums.Length == 1)
        {
            return new ValueWithOriginalIndex[] { nums[0] };
        }
        var left = MergeSort(nums[..(nums.Length / 2)], resultList);
        var right = MergeSort(nums[(nums.Length / 2)..], resultList);

        return Merge(left, right, resultList);
    }

    private ValueWithOriginalIndex[] Merge(ValueWithOriginalIndex[] left, ValueWithOriginalIndex[] right, int[] resultList)
    {
        var i = 0;
        var j = 0;
        var res = new ValueWithOriginalIndex[left.Length + right.Length];
        var k = 0;
        while (i < left.Length && j < right.Length)
        {
            if (left[i].Value <= right[j].Value)
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

        j = 0;
        var totalNumberOfSmallerRightValueComparedToLeftOne = 0;
        foreach (var valueWithOriginalIndex in left)
        {
            resultList[valueWithOriginalIndex.OriginalIndex] += totalNumberOfSmallerRightValueComparedToLeftOne;
            var currentNumberOfSmallerRightValueComparedToLeftOne = 0;
            while (j < right.Length && right[j].Value < valueWithOriginalIndex.Value)
            {
                j++;
                totalNumberOfSmallerRightValueComparedToLeftOne++;
                currentNumberOfSmallerRightValueComparedToLeftOne++;
            }
            resultList[valueWithOriginalIndex.OriginalIndex] += currentNumberOfSmallerRightValueComparedToLeftOne;
        }

        return res;
    }
}