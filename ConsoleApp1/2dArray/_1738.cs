using ConsoleApp1.Array;

namespace ConsoleApp1._2dArray;

public class _1738
{
    public int KthLargestValue(int[][] matrix, int k)
    {
        var minHeap = new MinHeap();
        //var priorityQueue = new PriorityQueue<int, int>();
        var count = 0;
        var temp = new int[matrix.Length * matrix[0].Length];
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                matrix[i][j] =
                    (i > 0 ? matrix[i - 1][j] : 0) ^
                    (j > 0 ? matrix[i][j - 1] : 0) ^
                    (i > 0 && j > 0 ? matrix[i - 1][j - 1] : 0) ^
                    matrix[i][j];
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

    private int FindKthLargest(int[] nums, int k, int start = 0, int end = -1)
    {
        if (end == -1)
        {
            end = nums.Length;
        }
        var boundary = LomutoPartition(nums, start, end);

        if (boundary < k)
        {
            return FindKthLargest(nums, k, boundary + 1, end);
        }
        if (boundary > k)
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
}