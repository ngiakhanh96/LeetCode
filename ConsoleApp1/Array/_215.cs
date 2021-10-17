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

        var kSmallestIndex = end - k;

        if (boundary < kSmallestIndex)
        {
            return FindKthLargest(nums, k, boundary + 1, end);
        }
        if (boundary > kSmallestIndex)
        {
            return FindKthLargest(nums, k - (end - boundary), start, boundary);
        }
        return nums[boundary];
    }

    private int LomutoPartition(int[] nums, int start, int end)
    {
        var pivot = nums[end - 1];
        var boundary = start;
        for (int i = start; i < end - 1; i++)
        {
            if (nums[i] < pivot)
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

        var kSmallestIndex = end - k;

        if (boundary < kSmallestIndex)
        {
            return FindKthLargest2(nums, k, boundary + 1, end);
        }
        if (boundary > kSmallestIndex)
        {
            return FindKthLargest2(nums, k - (end - boundary), start, boundary);
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
            if (nums[boundary] < pivot)
            {
                boundary++;
            }
            else if (nums[j] >= pivot)
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
        boundary += nums[boundary] >= pivot ? 0 : 1;

        var temp2 = nums[pivotIndex];
        nums[pivotIndex] = nums[boundary];
        nums[boundary] = temp2;

        return boundary;
    }
}