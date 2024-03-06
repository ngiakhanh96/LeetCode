namespace ConsoleApp1.Heap;

[LastVisited(2024, 3, 7)]
public class _1738
{
    public int KthLargestValue(int[][] matrix, int k)
    {
        var minHeap = new PriorityQueue<int, int>();
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
                if (minHeap.Count < k)
                {
                    minHeap.Enqueue(matrix[i][j]);
                }
                else
                {
                    if (matrix[i][j] > minHeap.Peek())
                    {
                        minHeap.DequeueEnqueue(matrix[i][j]);
                    }
                }
                temp[count++] = matrix[i][j];
            }
        }
        //Time: O(MNlogk)
        //Space: O(k)
        return minHeap.Peek();

        //Time: O(MNlog(MN))
        //Space: O(MN)
        //System.Array.Sort(temp, (x, y) => y.CompareTo(x));
        //return temp[k - 1];

        //Time: O(MN)
        //Space: O(MN)
        //return FindKthLargest(temp, k);


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

    //Time: O(MN)
    //Space: O(1)
    public int KthLargestValue2(int[][] matrix, int k)
    {
        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[0].Length; j++)
            {
                matrix[i][j] ^= (i - 1 >= 0 ? matrix[i - 1][j] : 0)
                ^ (j - 1 >= 0 ? matrix[i][j - 1] : 0)
                ^ (i - 1 >= 0 && j - 1 >= 0 ? matrix[i - 1][j - 1] : 0);
            }
        }

        k--;
        var start = 0;
        var end = (matrix.Length * matrix[0].Length) - 1;
        var boundary = -1;
        while (boundary != k)
        {
            if (boundary < k)
            {
                start = boundary + 1;
            }
            else
            {
                end = boundary - 1;
            }
            boundary = Partition(matrix, start, end);
        }
        var boundary2D = Convert1DPosTo2DPos(boundary, matrix[0].Length);
        return matrix[boundary2D[0]][boundary2D[1]];
    }

    //Time: O(MNlog(MN))
    //Space: O(MN)
    public int KthLargestValue3(int[][] matrix, int k)
    {
        var coordinateValues = new int[matrix.Length * matrix[0].Length];
        var index = 0;
        for (var r = 0; r < matrix.Length; r++)
        {
            for (var c = 0; c < matrix[0].Length; c++)
            {
                matrix[r][c] ^= (r > 0 ? matrix[r - 1][c] : 0) ^
                                (c > 0 ? matrix[r][c - 1] : 0) ^
                                (r > 0 && c > 0 ? matrix[r - 1][c - 1] : 0);
                coordinateValues[index] = matrix[r][c];
                index++;
            }
        }

        System.Array.Sort(coordinateValues);

        return coordinateValues[^k];
    }

    private int Partition(int[][] matrix, int start, int end)
    {
        var end2D = Convert1DPosTo2DPos(end, matrix[0].Length);
        var start2D = Convert1DPosTo2DPos(start, matrix[0].Length);
        var pivot = matrix[end2D[0]][end2D[1]];
        var boundary = start;

        for (var i = start; i < end; i++)
        {
            var i2D = Convert1DPosTo2DPos(i, matrix[0].Length);
            if (matrix[i2D[0]][i2D[1]] > pivot)
            {
                var boundary2D = Convert1DPosTo2DPos(boundary, matrix[0].Length);
                var temp = matrix[i2D[0]][i2D[1]];
                matrix[i2D[0]][i2D[1]] = matrix[boundary2D[0]][boundary2D[1]];
                matrix[boundary2D[0]][boundary2D[1]] = temp;
                boundary++;
            }
        }

        var boundary2D2 = Convert1DPosTo2DPos(boundary, matrix[0].Length);
        var temp2 = matrix[end2D[0]][end2D[1]];
        matrix[end2D[0]][end2D[1]] = matrix[boundary2D2[0]][boundary2D2[1]];
        matrix[boundary2D2[0]][boundary2D2[1]] = temp2;

        return boundary;
    }

    private int Convert2DPosTo1DPos(int[] pos, int n)
    {
        return pos[0] * n + pos[1];
    }

    private int[] Convert1DPosTo2DPos(int pos, int n)
    {
        return new[] { pos / n, pos % n };
    }
}