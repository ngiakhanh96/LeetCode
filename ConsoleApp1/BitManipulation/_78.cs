using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.BitManipulation
{
    public class _78
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            var returnList = new List<IList<int>>();
            for (int i = 0; i < Math.Pow(2, nums.Length); i++)
            {
                returnList.Add(GetUnmaskIndex(i, nums.Length).Select(ele => nums[ele]).ToList());
            }

            return returnList;
        }
        private IList<int> GetUnmaskIndex(int n, int length)
        {
            var complement = 1;
            var resultList = new List<int>();
            while (n != 0)
            {
                if (GetBit(n, 0) == 1)
                {
                    resultList = resultList.Prepend(length - complement).ToList();
                }

                n >>= 1;
                complement++;
            }

            return resultList;
        }

        private int GetBit(int n, int position)
        {
            return (n >> position) & 1;
        }
    }
}
