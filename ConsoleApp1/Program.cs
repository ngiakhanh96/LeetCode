global using ConsoleApp1.Heap;
global using ConsoleApp1.LinkedList;
global using ConsoleApp1.UnionFind;
using ConsoleApp1.BinarySearch;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        var t = new _378().KthSmallest(new int[][] { new[] { 1, 2 }, new[] { 1, 3 } }, 4);
    }

    public class NumMatrix
    {
        public NumMatrix()
        {
        }

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
    }
}