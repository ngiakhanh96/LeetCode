namespace ConsoleApp1.QuickSelect;

public class _215
{
    public int FindKthLargest(int[] nums, int k)
    {
        var indexPos = k - 1;
        var start = 0;
        var end = nums.Length - 1;
        var boundary = LomutoPartition(nums, start, end);

        while (boundary != indexPos)
        {
            if (boundary < indexPos)
            {
                start = boundary + 1;
            }
            else
            {
                end = boundary - 1;
            }
            boundary = LomutoPartition(nums, start, end);
        }

        return nums[boundary];
    }

    private int LomutoPartition(int[] nums, int start, int end)
    {
        var pivot = nums[end];
        var boundary = start;
        for (var i = start; i <= end - 1; i++)
        {
            if (nums[i] > pivot)
            {
                var temp = nums[i];
                nums[i] = nums[boundary];
                nums[boundary] = temp;
                boundary++;
            }
        }

        var temp2 = nums[end];
        nums[end] = nums[boundary];
        nums[boundary] = temp2;
        return boundary;
    }

    public int FindKthLargest2(int[] nums, int k)
    {
        var indexPos = k - 1;
        var start = 0;
        var end = nums.Length - 1;
        var boundary = HoarePartition(nums, start, end);

        while (boundary != indexPos)
        {
            if (boundary < indexPos)
            {
                start = boundary + 1;
            }
            else
            {
                end = boundary - 1;
            }
            boundary = HoarePartition(nums, start, end);
        }

        return nums[boundary];
    }

    private int HoarePartition(int[] nums, int start, int end)
    {
        var pivotIndex = start + (end - start) / 2;
        var pivot = nums[pivotIndex];
        var boundary = start;
        var j = end;
        // Need <= since in case of boundary == j; if (nums[boundary] > pivot) need boundary ++; else keep boundary. dont care about j
        while (boundary <= j)
        {
            if (nums[boundary] > pivot)
            {
                boundary++;
            }
            else if (nums[j] <= pivot)
            {
                j--;
            }
            else
            {
                // compare to boundary only since j can never stuck to pivotIndex due to the fact that nums[j] <= pivot
                if (pivotIndex == boundary)
                {
                    pivotIndex = j;
                }

                var temp = nums[boundary];
                nums[boundary] = nums[j];
                nums[j] = temp;
                boundary++;
                j--;
            }
        }

        var temp2 = nums[pivotIndex];
        nums[pivotIndex] = nums[boundary];
        nums[boundary] = temp2;

        return boundary;
    }

    public MinHeap MinHeap { get; set; }

    public int Size { get; set; }

    public int FindKthLargest3(int[] nums, int k)
    {
        Size = k;
        MinHeap = new MinHeap();
        foreach (var num in nums)
        {
            AddToHeap(num);
        }

        return MinHeap.Peek();
    }

    private void AddToHeap(int num)
    {
        if (MinHeap.Count < Size)
        {
            MinHeap.Add(num);
        }
        else
        {
            var currentSmallest = MinHeap.Peek();
            if (num > currentSmallest)
            {
                MinHeap.Pop();
                MinHeap.Add(num);
            }
        }
    }
}