namespace ConsoleApp1.Array;

public class _215
{
    public int FindKthLargest(int[] nums, int k, int start = 0, int end = -1)
    {
        if (end == -1)
        {
            end = nums.Length;
        }

        var boundary = LomutoPartition(nums, start, end);

        var kLargestIndex = k - 1;

        if (boundary < kLargestIndex)
        {
            return FindKthLargest(nums, k, boundary + 1, end);
        }
        if (boundary > kLargestIndex)
        {
            return FindKthLargest(nums, k, start, boundary);
        }
        return nums[boundary];
    }

    private int LomutoPartition(int[] nums, int start, int end)
    {
        var pivot = nums[end - 1];
        var boundary = start;
        for (int i = start; i < end - 1; i++)
        {
            if (nums[i] > pivot)
            {
                var temp = nums[i];
                nums[i] = nums[boundary];
                nums[boundary] = temp;
                boundary++;
            }
        }

        var temp2 = nums[end - 1];
        nums[end - 1] = nums[boundary];
        nums[boundary] = temp2;
        return boundary;
    }

    public int FindKthLargest2(int[] nums, int k, int start = 0, int end = -1)
    {
        if (end == -1)
        {
            end = nums.Length;
        }

        var boundary = HoarePartition(nums, start, end);

        var kLargestIndex = k - 1;

        if (boundary < kLargestIndex)
        {
            return FindKthLargest(nums, k, boundary + 1, end);
        }
        if (boundary > kLargestIndex)
        {
            return FindKthLargest(nums, k, start, boundary);
        }
        return nums[boundary];
    }

    private int HoarePartition(int[] nums, int start, int end)
    {
        var pivotIndex = (end + start) / 2;
        var pivot = nums[pivotIndex];
        var boundary = start;
        var j = end - 1;
        while (boundary < j)
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
                if (pivotIndex == boundary)
                {
                    pivotIndex = j;
                }

                else if (pivotIndex == j)
                {
                    pivotIndex = boundary;
                }

                var temp = nums[boundary];
                nums[boundary] = nums[j];
                nums[j] = temp;
                boundary++;
                j--;
            }
        }
        boundary += nums[boundary] <= pivot ? 0 : 1;

        var temp2 = nums[pivotIndex];
        nums[pivotIndex] = nums[boundary];
        nums[boundary] = temp2;

        return boundary;
    }

    public MinHeap MinHeap { get; set; }
    public int FindKthLargest3(int[] nums, int k)
    {
        MinHeap = new MinHeap(k);
        foreach (var num in nums)
        {
            AddToHeap(num);
        }

        return MinHeap.Peek();
    }

    private void AddToHeap(int num)
    {
        if (!MinHeap.IsFull())
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