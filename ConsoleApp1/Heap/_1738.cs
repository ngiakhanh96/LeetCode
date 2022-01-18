namespace ConsoleApp1.Heap;

public class _1738
{
    public int KthLargestValue(int[][] matrix, int k)
    {
        var minHeap = new MinHeap();
        //var priorityQueue = new PriorityQueue<int, int>();
        var count = 0;
        var temp = new int[matrix.Length * matrix[0].Length];
        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[0].Length; j++)
            {
                matrix[i][j] ^=
                    (i > 0 ? matrix[i - 1][j] : 0) ^
                    (j > 0 ? matrix[i][j - 1] : 0) ^
                    (i > 0 && j > 0 ? matrix[i - 1][j - 1] : 0);
                //if (priorityQueue.Count < k)
                //{
                //    priorityQueue.Enqueue(matrix[i][j]);
                //}
                //else
                //{
                //    if (matrix[i][j] > priorityQueue.Peek())
                //    {
                //        priorityQueue.DequeueEnqueue(matrix[i][j]);
                //    }
                //}
                if (minHeap.Count < k)
                {
                    minHeap.Add(matrix[i][j]);
                }
                else
                {
                    if (matrix[i][j] > minHeap.Peek())
                    {
                        minHeap.Pop();
                        minHeap.Add(matrix[i][j]);
                    }
                }
                temp[count++] = matrix[i][j];
            }
        }
        //Time: O(MNlogk)
        //Space: O(k)
        //return priorityQueue.Peek();
        return minHeap.Peek();

        //Time: O(MNlog(MN))
        //Space: O(MN)
        //System.Array.Sort(temp, (x, y) => y.CompareTo(x));
        //return temp[k - 1];

        //Time: O(MN)
        //Space: O(MN)
        //return FindKthLargest(temp, k - 1);
    }

    private int FindKthLargest(int[] nums, int k)
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

    private int HoarePartition(int[] nums, int start, int end)
    {
        var pivotIndex = start + (end - start) / 2;
        var pivot = nums[pivotIndex];
        var boundary = start;
        var j = end;
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
}