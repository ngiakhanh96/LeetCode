namespace ConsoleApp1.BitManipulation;

[LastVisited(2024, 3, 5)]
public class _78
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        var result = new List<IList<int>>();
        for (var i = 0; i < Math.Pow(2, nums.Length); i++)
        {
            var mask = i;
            var subResult = new List<int>();
            for (var y = nums.Length - 1; y >= 0; y--)
            {
                var bit = mask & 1;
                if (bit == 1)
                {
                    subResult.Add(nums[y]);
                }
                mask >>= 1;
            }
            result.Add(subResult);
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