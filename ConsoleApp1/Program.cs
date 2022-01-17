global using ConsoleApp1.Heap;
global using ConsoleApp1.LinkedList;
global using ConsoleApp1.UnionFind;
using ConsoleApp1.BinarySearch;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        var t = new _34().SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8);
        var a = new NumMatrix();
        var b = a.Subsets(new int[] { 1, 2, 3 });
    }

    public class NumMatrix
    {
        public NumMatrix()
        {
        }

        public IList<IList<int>> Subsets(int[] nums)
        {
            var res = new List<IList<int>>();
            for (var i = 0; i < Math.Pow(2, nums.Length); i++)
            {
                res.Add(GetSubSet(i, nums));
            }
            return res;
        }

        private List<int> GetSubSet(int num, int[] nums)
        {
            var unmaskedBits = new List<int>();
            for (var i = nums.Length - 1; i >= 0; i--)
            {
                if ((num & 1) == 1)
                {
                    unmaskedBits.Add(i);
                }
                num = num >> 1;
            }

            return unmaskedBits.Select(p => nums[p]).ToList();
        }
    }
}