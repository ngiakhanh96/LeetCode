namespace ConsoleApp1.BitManipulation;

// Last visit 4/6/2022
public class _78
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        var result = new List<IList<int>> { new List<int>() };
        var start = 1;
        var end = (int)Math.Pow(2, nums.Length);
        for (var i = start; i < end; i++)
        {
            var subset = new List<int>();
            var curr = i;
            for (var a = nums.Length - 1; a >= 0; a--)
            {
                if ((curr & 1) == 1)
                {
                    subset.Add(nums[a]);
                }
                curr >>= 1;
            }

            result.Add(subset);
        }

        return result;
    }

    public IList<IList<int>> Subsets2(int[] nums)
    {
        var returnList = new List<IList<int>>();
        for (var i = 0; i < Math.Pow(2, nums.Length); i++)
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